﻿@"
using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.Common;
using System.Collections.Immutable;
using Npgsql;
using System.Linq;

namespace $($namespace)
{
    public class DBPersist
    {
        public delegate void SelectCallback(DbDataReader rdr);
        
        static public void select( SelectCallback selectCallback, string sql)
        {
            // Retrieve all rows
            /*

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            await using (var cmd = new NpgsqlCommand("SELECT some_field FROM data", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
            while (await reader.ReadAsync())
                Console.WriteLine(reader.GetString(0));
            }
            */

            string connectionStr = Config.getString("db.connection");

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionStr))
            {
                connection.Open();

                using (DbCommand command = (DbCommand) new NpgsqlCommand(sql, connection))
                {
                    using (DbDataReader rdr = (DbDataReader) command.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            selectCallback(rdr);
                        }
                    }
                }
            }
        }

        static public void select( SelectCallback selectCallback, string sqlTemplate, Tuple filter)
        {
            string sql = substituteTemplate(filter, sqlTemplate);

            select(selectCallback, sql);
        }

        static public long insert( Tuple tuple )
        {
            long id = identity();
            int ver = version(tuple);

            tuple.setPropValue("id", id);
            tuple.setPropValue("version", ver);
            tuple.setPropValue("last_updated", DateTime.Now);
            tuple.setPropValue("last_updated_by", Environment.UserName);
            string sql = insertSql(tuple, tuple.tableName);
            execCmd(sql);

            audit(tuple);

            return id;
        }

        static public long audit( Tuple tuple )
        {
            Tuple auditTuple = new Tuple(tuple);

            string auditFKCol = tuple.tableBaseName + "_id";
            auditTuple.setPropValue(auditFKCol, tuple["id"]);
            long id = identity();
            auditTuple.setPropValue("id", id);

            Console.WriteLine("Audit: " + auditTuple.ToString());

            string sql = insertSql(auditTuple, tuple.auditTableName);
            execCmd(sql);

            return id;
        }
        static public void update(Tuple tuple)
        {
            tuple.setPropValue("version", version(tuple));

            string sql = updateSql(tuple);
            execCmd(sql);

            audit(tuple);
        }

        public static void execCmd( Tuple parameters, string sqlTemplate)
        {
            string sql = substituteTemplate(parameters, sqlTemplate);
            execCmd(sql);
        }
        public static void execCmd(string sql)
        {
            try
            {
                string connectionStr = Config.getString("db.connection");

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionStr))
                {
                    connection.Open();

                    using (DbCommand command = (DbCommand) new NpgsqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception x)
            {
                Console.WriteLine(x.Message + ": " + sql);
            }
        }

        static string insertSql( Tuple tuple, string tableName )
        {
            StringBuilder sql = new StringBuilder("insert into " + tableName + " ");
            StringBuilder cols = new StringBuilder("");
            StringBuilder vals = new StringBuilder("");

            foreach (string k in tuple.Keys)
            {
                //if (k != "id")
                //{
                    object v = tuple[k];

                    if (cols.Length > 0)
                    {
                        cols.Append(",");
                        vals.Append(",");
                    }
                    cols.Append(bracket(k));
                    vals.Append(toSql(v));
                //}
            }

            sql.Append("(");
            sql.Append(cols);
            sql.Append(") values (");
            sql.Append(vals);
            sql.Append(");");

            return sql.ToString();
        }

        static string updateSql( Tuple tuple)
        {
            StringBuilder sql = new StringBuilder("update " + tuple.tableName + " set ");
            StringBuilder expressions = new StringBuilder();
            StringBuilder where = new StringBuilder();

            exprSql(tuple, tuple.Keys, ", ", expressions);

            where.Append(" where id=");
            where.Append(toSql(tuple["id"]));

            sql.Append(expressions);
            sql.Append(where);
            sql.Append(";");

            return sql.ToString();
        }

        private static void exprSql(Tuple tuple, IEnumerable<string> attrList, string sepToken, StringBuilder expressions)
        {
            foreach (string k in attrList)
            {
                if (k != "id")
                {
                    if (expressions.Length > 0)
                    {
                        expressions.Append(sepToken);
                    }
                    string expr = string.Empty;
                    expr += bracket(k);
                    expr += "=";
                    expr += toSql(tuple[k]);

                    expressions.Append(expr);
                }
            }
        }

        
        static string bracket(string k)
        {
            //return "[" + k + "]";
            return k;
        }

        static string toSql( object v)
        {
            string result = string.Empty;

            if (v.GetType().Equals(typeof(DateTime)))
            {
                DateTime d = (DateTime)v;
                result = "'" + d.ToString("MM/dd/yyyy HH:mm:ss") +"'";
            }
            else if (v.GetType().Equals(typeof(string)))
            {
                result = "'" + v.ToString().Replace("'", "''") + "'";
            }
            else if (v.GetType().FullName.Contains("Text"))
            {
                result = "'" + v.ToString().Replace("'", "''") + "'";
            }
            else
            {
                result = v.ToString();
            }

            return result;
          
        }

        static public void get(Tuple t)
        {
            string sql = getSql(t);

            SelectCallback sc = (rdr) =>
            {
                autoAssign(rdr, t);
            };

            select(sc, sql);
        }


        static public void put(Tuple tuple, string rwkCol)
        {
            string sql = "select * from ^(tableName) where ^(rwkCol) = ^(rwkValue)";
            bool found = false;

            Tuple filter = new Tuple();
            filter["tableName"] = tuple.tableName;
            filter["rwkCol"] = rwkCol;
            filter["rwkValue"] = toSql(tuple[rwkCol].ToString());

            SelectCallback scb = (rdr) =>
            {
                found = true;
                tuple["id"] = rdr["id"];
            };

            select(scb, sql, filter);

            if (found)
            {
                update(tuple);
            }
            else
            {
                insert(tuple);
            }
        }

        static public void put(Tuple tuple)
        {
            string sql = "select * from ^(tableName) where ^(expression)";
            int count = 0;
            StringBuilder expression = new StringBuilder();

            if (tuple.getRwk().Count <= 0) throw new Exception(tuple.GetType().Name + ".rwk list is empty. DBPersist.put(Tuple) requires at least one attribute in the rwk list.");

            exprSql(tuple, tuple.getRwk(), " and ", expression);

            Tuple filter = new Tuple();
            filter["tableName"] = tuple.tableName;
            filter["expression"] = expression.ToString();

            SelectCallback scb = (rdr) =>
            {
                count++;
                tuple["id"] = rdr["id"];
            };

            select(scb, sql, filter);

            if (count == 1)
            {
                update(tuple);
            }
            else if (count == 0)
            {
                insert(tuple);
            }
            else
            {
                throw new Exception(tuple.GetType().Name + ".rwk returned more that one row. sql=" + sql); ;
            }
        }

        static long identity()
        {
            long id = 0;

            //string sql = "select next value for object_identity";
            string sql = "SELECT nextval('object_identity');";

            SelectCallback scb = (rdr) =>
            {
                id = Convert.ToInt64(rdr[0]);
            };

            select(scb, sql);

            return id;
        }

        static int version(Tuple tuple)
        {
            int ver = 0;

            

            string sqlTemplate = @"with ver_check as (
            select max(version) as v from ^(table)
            where id=^(id)
            union all select 0 as v
            )
            select max(v)+1 from ver_check";

            legr.Tuple p = new Tuple();
            
            long id = 0;
            if (tuple.ContainsKey("id"))
            {
                id = Convert.ToInt64(tuple["id"]);
            }
                
            
            p["table"] = tuple.tableName;
            p["id"] = id;
            string sql = substituteTemplate(p, sqlTemplate);

            SelectCallback scb = (rdr) =>
            {
                ver = Convert.ToInt32(rdr[0]);
            };

            select(scb, sql);

            return ver;
        }
        static string getSql( Tuple t)
        {
            string sqlTemplate = "select * from ^(table) where id=^(id)";

            legr.Tuple p = new Tuple();

            p["id"] = t["id"];
            p["table"] = t.tableName;

            return substituteTemplate(p, sqlTemplate);

        }

        public static void autoAssign( DbDataReader rdr, Tuple t)
        {
            for (int i = 0; i < rdr.FieldCount; i++)
            {
                string k = rdr.GetName(i);
                if (t.ContainsKey(k)) { t[k] = rdr.GetValue(i); }
                else { t.Add(k, rdr.GetValue(i)); }
            }
        }

        protected static string substituteTemplate( Tuple parameters, string sqlTemplate)
        {
            StringBuilder sb = new StringBuilder(sqlTemplate);

            foreach( string k in parameters.Keys)
            {
                object v = string.Empty;
                parameters.TryGetValue(k, out v);

                string paramName = "^(" + k + ")";
                sb.Replace(paramName, v.ToString());
            }

            return sb.ToString();
        }

    }
}
"@
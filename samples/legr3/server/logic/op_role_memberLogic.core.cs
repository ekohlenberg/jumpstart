
using System;


namespace legr3
{
    

    public partial class OpRoleMemberLogic
    {

        protected static Dictionary< string, bool> authorizedCache = new();
        protected static object cacheLock = new object();

        public static bool Authorized( string objectName, string methodName )
        {
            string[] keyArray = new  string[] { Environment.UserName, objectName, methodName};

            string key = string.Join(":", keyArray);

            bool result = false;

            lock(cacheLock)
            {
                if (authorizedCache.ContainsKey(key))
                {
                    result = authorizedCache[key];
                }
                else
                {
                    string sql = @"select 1 from
sec.operation op
inner join sec.op_role_map orm on
    orm.op_id=op.id
inner join sec.op_role r on
    r.id=orm.op_role_id
inner join sec.op_role_member m on
    m.op_role_id=r.id
inner join app.""user"" u on 
    u.id=m.user_id
where
    op.objectname='^(objectname)' and
    op.methodname='^(methodname)' and
    u.username='^(username)'";

                    BaseObject filter = new();
                    filter["objectname"] = objectName;
                    filter["methodname"] = methodName;
                    filter["username"] = Environment.UserName;

                    void authCallback(System.Data.Common.DbDataReader rdr)
                    {
                        result = true;
                    };
                    
                    DBPersist.select( authCallback, sql, filter);

                    authorizedCache[key] = result;
                }
            } 

            return result;
        }
        
    }
}


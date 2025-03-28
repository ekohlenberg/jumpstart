
using System;
using System.Reflection;

namespace legr3
{
    [Label("Operation Role Members")]
    public partial class OpRoleMember : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "OpRoleMember";
            tableName = "sec.op_role_member";
            tableBaseName = "op_role_member";
            auditTableName = "audit.sec_op_role_member";


            rwk.Add("user_id");
            
            rwk.Add("op_role_id");
                    }


            [Label("Member ID")]
            public long id
            {
                get
                {
                    long _id;

                             _id = default(long);
                                                 
                    if(this.ContainsKey("id"))
                    {
                       _id = Convert.ToInt64(this["id"].ToString());
                    }
                    return _id;
                }
                set
                {
                   
                    this["id"] = value;
                }
            }
            
            [Label("Username")]
            public long user_id
            {
                get
                {
                    long _user_id;

                             _user_id = default(long);
                                                 
                    if(this.ContainsKey("user_id"))
                    {
                       _user_id = Convert.ToInt64(this["user_id"].ToString());
                    }
                    return _user_id;
                }
                set
                {
                   
                    this["user_id"] = value;
                }
            }
            
            [Label("Role")]
            public long op_role_id
            {
                get
                {
                    long _op_role_id;

                             _op_role_id = default(long);
                                                 
                    if(this.ContainsKey("op_role_id"))
                    {
                       _op_role_id = Convert.ToInt64(this["op_role_id"].ToString());
                    }
                    return _op_role_id;
                }
                set
                {
                   
                    this["op_role_id"] = value;
                }
            }
            
            [Label("Active")]
            public int is_active
            {
                get
                {
                    int _is_active;

                             _is_active = default(int);
                                                 
                    if(this.ContainsKey("is_active"))
                    {
                       _is_active = Convert.ToInt32(this["is_active"].ToString());
                    }
                    return _is_active;
                }
                set
                {
                   
                    this["is_active"] = value;
                }
            }
            
            [Label("Created By")]
            public string created_by
            {
                get
                {
                    string _created_by;

                            _created_by = string.Empty;
                                                
                    if(this.ContainsKey("created_by"))
                    {
                       _created_by = Convert.ToString(this["created_by"].ToString());
                    }
                    return _created_by;
                }
                set
                {
                   
                    this["created_by"] = value;
                }
            }
            
            [Label("Last Updated")]
            public DateTime last_updated
            {
                get
                {
                    DateTime _last_updated;

                             _last_updated = default(DateTime);
                                                 
                    if(this.ContainsKey("last_updated"))
                    {
                       _last_updated = Convert.ToDateTime(this["last_updated"].ToString());
                    }
                    return _last_updated;
                }
                set
                {
                   
                    this["last_updated"] = value;
                }
            }
            
            [Label("Last Updated By")]
            public string last_updated_by
            {
                get
                {
                    string _last_updated_by;

                            _last_updated_by = string.Empty;
                                                
                    if(this.ContainsKey("last_updated_by"))
                    {
                       _last_updated_by = Convert.ToString(this["last_updated_by"].ToString());
                    }
                    return _last_updated_by;
                }
                set
                {
                   
                    this["last_updated_by"] = value;
                }
            }
            
            [Label("Version")]
            public int version
            {
                get
                {
                    int _version;

                             _version = default(int);
                                                 
                    if(this.ContainsKey("version"))
                    {
                       _version = Convert.ToInt32(this["version"].ToString());
                    }
                    return _version;
                }
                set
                {
                   
                    this["version"] = value;
                }
            }
                }
}

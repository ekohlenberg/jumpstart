
using System;
using System.Reflection;

namespace legr3
{
    [Label("Password")]
    public partial class UserPassword : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "UserPassword";
            tableName = "sec.user_password";
            tableBaseName = "user_password";
            auditTableName = "audit.sec_user_password";


            rwk.Add("user_id");
                    }


            [Label("User ID")]
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
            
            [Label("User ID")]
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
            
            [Label("Password")]
            public string password_hash
            {
                get
                {
                    string _password_hash;

                            _password_hash = string.Empty;
                                                
                    if(this.ContainsKey("password_hash"))
                    {
                       _password_hash = Convert.ToString(this["password_hash"].ToString());
                    }
                    return _password_hash;
                }
                set
                {
                   
                    this["password_hash"] = value;
                }
            }
            
            [Label("Expiry")]
            public DateTime expiry
            {
                get
                {
                    DateTime _expiry;

                             _expiry = default(DateTime);
                                                 
                    if(this.ContainsKey("expiry"))
                    {
                       _expiry = Convert.ToDateTime(this["expiry"].ToString());
                    }
                    return _expiry;
                }
                set
                {
                   
                    this["expiry"] = value;
                }
            }
            
            [Label("Needs Reset")]
            public int needs_reset
            {
                get
                {
                    int _needs_reset;

                             _needs_reset = default(int);
                                                 
                    if(this.ContainsKey("needs_reset"))
                    {
                       _needs_reset = Convert.ToInt32(this["needs_reset"].ToString());
                    }
                    return _needs_reset;
                }
                set
                {
                   
                    this["needs_reset"] = value;
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

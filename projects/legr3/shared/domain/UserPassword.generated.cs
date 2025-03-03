
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
                    return Convert.ToInt64(this["id"]);
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
                    return Convert.ToInt64(this["user_id"]);
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
                    return Convert.ToString(this["password_hash"]);
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
                    return Convert.ToDateTime(this["expiry"]);
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
                    return Convert.ToInt32(this["needs_reset"]);
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
                    return Convert.ToInt32(this["is_active"]);
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
                    return Convert.ToString(this["created_by"]);
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
                    return Convert.ToDateTime(this["last_updated"]);
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
                    return Convert.ToString(this["last_updated_by"]);
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
                    return Convert.ToInt32(this["version"]);
                }
                set
                {
                   
                    this["version"] = value;
                }
            }
                }
}

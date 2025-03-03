
using System;
using System.Reflection;

namespace legr3
{
    [Label("Users")]
    public partial class UserOrg : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "UserOrg";
            tableName = "app.user_org";
            tableBaseName = "user_org";
            auditTableName = "audit.app_user_org";


            rwk.Add("org_id");
            
            rwk.Add("user_id");
                    }


            [Label("User Org ID")]
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
            
            [Label("Organization ID")]
            public long org_id
            {
                get
                {
                    return Convert.ToInt64(this["org_id"]);
                }
                set
                {
                   
                    this["org_id"] = value;
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


using System;
using System.Reflection;

namespace legr3
{
    public partial class Account : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Account";
            tableName = "app.account";
            tableBaseName = "account";
            auditTableName = "audit.app_account";


            rwk.Add("org_id");
            
            rwk.Add("account_name");
                    }


            
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
            
            
            public string account_name
            {
                get
                {
                    return Convert.ToString(this["account_name"]);
                }
                set
                {
                   
                    this["account_name"] = value;
                }
            }
            
            
            public string account_type
            {
                get
                {
                    return Convert.ToString(this["account_type"]);
                }
                set
                {
                   
                    this["account_type"] = value;
                }
            }
            
            
            public object balance
            {
                get
                {
                    return Convert.ToDouble(this["balance"]);
                }
                set
                {
                   
                    this["balance"] = value;
                }
            }
            
            
            public DateTime created_date
            {
                get
                {
                    return Convert.ToDateTime(this["created_date"]);
                }
                set
                {
                   
                    this["created_date"] = value;
                }
            }
            
            
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

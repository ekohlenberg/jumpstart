
using System;
using System.Reflection;

namespace legr3
{
    [Label("Account")]
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


            [Label("Account ID")]
            public long id
            {
                get
                {
                    return Convert.ToInt64(this["id"].ToString());
                }
                set
                {
                   
                    this["id"] = value;
                }
            }
            
            [Label("Organization")]
            public long org_id
            {
                get
                {
                    return Convert.ToInt64(this["org_id"].ToString());
                }
                set
                {
                   
                    this["org_id"] = value;
                }
            }
            
            [Label("Name")]
            public string account_name
            {
                get
                {
                    return Convert.ToString(this["account_name"].ToString());
                }
                set
                {
                   
                    this["account_name"] = value;
                }
            }
            
            [Label("Type")]
            public string account_type
            {
                get
                {
                    return Convert.ToString(this["account_type"].ToString());
                }
                set
                {
                   
                    this["account_type"] = value;
                }
            }
            
            [Label("Balance")]
            public object balance
            {
                get
                {
                    return Convert.ToDouble(this["balance"].ToString());
                }
                set
                {
                   
                    this["balance"] = value;
                }
            }
            
            [Label("Created")]
            public DateTime created_date
            {
                get
                {
                    return Convert.ToDateTime(this["created_date"].ToString());
                }
                set
                {
                   
                    this["created_date"] = value;
                }
            }
            
            [Label("Active")]
            public int is_active
            {
                get
                {
                    return Convert.ToInt32(this["is_active"].ToString());
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
                    return Convert.ToString(this["created_by"].ToString());
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
                    return Convert.ToDateTime(this["last_updated"].ToString());
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
                    return Convert.ToString(this["last_updated_by"].ToString());
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
                    return Convert.ToInt32(this["version"].ToString());
                }
                set
                {
                   
                    this["version"] = value;
                }
            }
                }
}

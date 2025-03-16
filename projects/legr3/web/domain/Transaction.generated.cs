
using System;
using System.Reflection;

namespace legr3
{
    [Label("Transaction")]
    public partial class Transaction : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Transaction";
            tableName = "app.transaction";
            tableBaseName = "transaction";
            auditTableName = "audit.app_transaction";

        }


            [Label("Transaction ID")]
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
            
            [Label("Account ID")]
            public long account_id
            {
                get
                {
                    return Convert.ToInt64(this["account_id"].ToString());
                }
                set
                {
                   
                    this["account_id"] = value;
                }
            }
            
            [Label("Organization ID")]
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
            
            [Label("Transaction Date")]
            public DateTime transaction_date
            {
                get
                {
                    return Convert.ToDateTime(this["transaction_date"].ToString());
                }
                set
                {
                   
                    this["transaction_date"] = value;
                }
            }
            
            [Label("Amount")]
            public object amount
            {
                get
                {
                    return Convert.ToDouble(this["amount"].ToString());
                }
                set
                {
                   
                    this["amount"] = value;
                }
            }
            
            [Label("Transaction Type")]
            public string transaction_type
            {
                get
                {
                    return Convert.ToString(this["transaction_type"].ToString());
                }
                set
                {
                   
                    this["transaction_type"] = value;
                }
            }
            
            [Label("Description")]
            public string description
            {
                get
                {
                    return Convert.ToString(this["description"].ToString());
                }
                set
                {
                   
                    this["description"] = value;
                }
            }
            
            [Label("Created Date")]
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

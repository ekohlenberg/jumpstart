
using System;
using System.Reflection;

namespace legr3
{
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
            
            
            public long account_id
            {
                get
                {
                    return Convert.ToInt64(this["account_id"]);
                }
                set
                {
                   
                    this["account_id"] = value;
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
            
            
            public DateTime transaction_date
            {
                get
                {
                    return Convert.ToDateTime(this["transaction_date"]);
                }
                set
                {
                   
                    this["transaction_date"] = value;
                }
            }
            
            
            public object amount
            {
                get
                {
                    return Convert.ToDouble(this["amount"]);
                }
                set
                {
                   
                    this["amount"] = value;
                }
            }
            
            
            public string transaction_type
            {
                get
                {
                    return Convert.ToString(this["transaction_type"]);
                }
                set
                {
                   
                    this["transaction_type"] = value;
                }
            }
            
            
            public string description
            {
                get
                {
                    return Convert.ToString(this["description"]);
                }
                set
                {
                   
                    this["description"] = value;
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

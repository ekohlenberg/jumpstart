
using System;
using System.Reflection;

namespace legr3
{
    public partial class TransactionCategory : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "TransactionCategory";
            tableName = "app.transaction_category";
            tableBaseName = "transaction_category";
            auditTableName = "audit.app_transaction_category";

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
            
            
            public long transaction_id
            {
                get
                {
                    return Convert.ToInt64(this["transaction_id"]);
                }
                set
                {
                   
                    this["transaction_id"] = value;
                }
            }
            
            
            public long category_id
            {
                get
                {
                    return Convert.ToInt64(this["category_id"]);
                }
                set
                {
                   
                    this["category_id"] = value;
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

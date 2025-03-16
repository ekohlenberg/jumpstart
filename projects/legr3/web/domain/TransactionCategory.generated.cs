
using System;
using System.Reflection;

namespace legr3
{
    [Label("Category Map")]
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


            [Label("Transaction-Category ID")]
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
            
            [Label("Transaction ID")]
            public long transaction_id
            {
                get
                {
                    return Convert.ToInt64(this["transaction_id"].ToString());
                }
                set
                {
                   
                    this["transaction_id"] = value;
                }
            }
            
            [Label("Category ID")]
            public long category_id
            {
                get
                {
                    return Convert.ToInt64(this["category_id"].ToString());
                }
                set
                {
                   
                    this["category_id"] = value;
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

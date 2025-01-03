
using System;
using System.Reflection;

namespace legr3
{
    public partial class TransactionCategory : BaseObject
    {
        protected void initialize()
        {
            // Default initializer
            tableName = "app.transaction_category";
            tableBaseName = "transaction_category";
            auditTableName = "audit.app_transaction_category";

        }


            public long id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("id"));
                }
                set
                {
                    setPropValue("id", value);
                }
            }
            
            public long transaction_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("transaction_id"));
                }
                set
                {
                    setPropValue("transaction_id", value);
                }
            }
            
            public long category_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("category_id"));
                }
                set
                {
                    setPropValue("category_id", value);
                }
            }
            
            public int is_active
            {
                get
                {
                    return Convert.ToInt32(getPropValue("is_active"));
                }
                set
                {
                    setPropValue("is_active", value);
                }
            }
            
            public string created_by
            {
                get
                {
                    return Convert.ToString(getPropValue("created_by"));
                }
                set
                {
                    setPropValue("created_by", value);
                }
            }
            
            public DateTime last_updated
            {
                get
                {
                    return Convert.ToDateTime(getPropValue("last_updated"));
                }
                set
                {
                    setPropValue("last_updated", value);
                }
            }
            
            public string last_updated_by
            {
                get
                {
                    return Convert.ToString(getPropValue("last_updated_by"));
                }
                set
                {
                    setPropValue("last_updated_by", value);
                }
            }
            
            public int version
            {
                get
                {
                    return Convert.ToInt32(getPropValue("version"));
                }
                set
                {
                    setPropValue("version", value);
                }
            }
                }
}

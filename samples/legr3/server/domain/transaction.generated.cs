
using System;
using System.Reflection;

namespace legr3
{
    public partial class Transaction : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            tableName = "app.transaction";
            tableBaseName = "transaction";
            auditTableName = "audit.app_transaction";

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
            
            public long account_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("account_id"));
                }
                set
                {
                    setPropValue("account_id", value);
                }
            }
            
            public long org_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("org_id"));
                }
                set
                {
                    setPropValue("org_id", value);
                }
            }
            
            public DateTime transaction_date
            {
                get
                {
                    return Convert.ToDateTime(getPropValue("transaction_date"));
                }
                set
                {
                    setPropValue("transaction_date", value);
                }
            }
            
            public object amount
            {
                get
                {
                    return Convert.ToDouble(getPropValue("amount"));
                }
                set
                {
                    setPropValue("amount", value);
                }
            }
            
            public string transaction_type
            {
                get
                {
                    return Convert.ToString(getPropValue("transaction_type"));
                }
                set
                {
                    setPropValue("transaction_type", value);
                }
            }
            
            public string description
            {
                get
                {
                    return Convert.ToString(getPropValue("description"));
                }
                set
                {
                    setPropValue("description", value);
                }
            }
            
            public DateTime created_date
            {
                get
                {
                    return Convert.ToDateTime(getPropValue("created_date"));
                }
                set
                {
                    setPropValue("created_date", value);
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

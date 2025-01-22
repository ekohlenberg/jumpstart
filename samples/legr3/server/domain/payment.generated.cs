
using System;
using System.Reflection;

namespace legr3
{
    public partial class Payment : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Payment";
            tableName = "app.payment";
            tableBaseName = "payment";
            auditTableName = "audit.app_payment";

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
            
            public long invoice_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("invoice_id"));
                }
                set
                {
                    setPropValue("invoice_id", value);
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
            
            public DateTime payment_date
            {
                get
                {
                    return Convert.ToDateTime(getPropValue("payment_date"));
                }
                set
                {
                    setPropValue("payment_date", value);
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
            
            public string payment_method
            {
                get
                {
                    return Convert.ToString(getPropValue("payment_method"));
                }
                set
                {
                    setPropValue("payment_method", value);
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

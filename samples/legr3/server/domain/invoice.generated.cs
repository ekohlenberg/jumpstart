
using System;
using System.Reflection;

namespace legr3
{
    public partial class Invoice : BaseObject
    {
        protected void initialize()
        {
            // Default initializer
            tableName = "app.invoice";
            tableBaseName = "invoice";
            auditTableName = "audit.app_invoice";

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
            
            public long customer_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("customer_id"));
                }
                set
                {
                    setPropValue("customer_id", value);
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
            
            public long invoice_number
            {
                get
                {
                    return Convert.ToInt64(getPropValue("invoice_number"));
                }
                set
                {
                    setPropValue("invoice_number", value);
                }
            }
            
            public DateTime invoice_date
            {
                get
                {
                    return Convert.ToDateTime(getPropValue("invoice_date"));
                }
                set
                {
                    setPropValue("invoice_date", value);
                }
            }
            
            public DateTime due_date
            {
                get
                {
                    return Convert.ToDateTime(getPropValue("due_date"));
                }
                set
                {
                    setPropValue("due_date", value);
                }
            }
            
            public object total_amount
            {
                get
                {
                    return Convert.ToDouble(getPropValue("total_amount"));
                }
                set
                {
                    setPropValue("total_amount", value);
                }
            }
            
            public string status
            {
                get
                {
                    return Convert.ToString(getPropValue("status"));
                }
                set
                {
                    setPropValue("status", value);
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


using System;
using System.Reflection;

namespace legr3
{
    public partial class Bill : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Bill";
            tableName = "app.bill";
            tableBaseName = "bill";
            auditTableName = "audit.app_bill";

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
            
            public long vendor_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("vendor_id"));
                }
                set
                {
                    setPropValue("vendor_id", value);
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
            
            public long bill_number
            {
                get
                {
                    return Convert.ToInt64(getPropValue("bill_number"));
                }
                set
                {
                    setPropValue("bill_number", value);
                }
            }
            
            public DateTime bill_date
            {
                get
                {
                    return Convert.ToDateTime(getPropValue("bill_date"));
                }
                set
                {
                    setPropValue("bill_date", value);
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

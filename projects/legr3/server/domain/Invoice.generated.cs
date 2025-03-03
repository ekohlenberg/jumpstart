
using System;
using System.Reflection;

namespace legr3
{
    public partial class Invoice : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Invoice";
            tableName = "app.invoice";
            tableBaseName = "invoice";
            auditTableName = "audit.app_invoice";

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
            
            
            public long customer_id
            {
                get
                {
                    return Convert.ToInt64(this["customer_id"]);
                }
                set
                {
                   
                    this["customer_id"] = value;
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
            
            
            public long invoice_number
            {
                get
                {
                    return Convert.ToInt64(this["invoice_number"]);
                }
                set
                {
                   
                    this["invoice_number"] = value;
                }
            }
            
            
            public DateTime invoice_date
            {
                get
                {
                    return Convert.ToDateTime(this["invoice_date"]);
                }
                set
                {
                   
                    this["invoice_date"] = value;
                }
            }
            
            
            public DateTime due_date
            {
                get
                {
                    return Convert.ToDateTime(this["due_date"]);
                }
                set
                {
                   
                    this["due_date"] = value;
                }
            }
            
            
            public object total_amount
            {
                get
                {
                    return Convert.ToDouble(this["total_amount"]);
                }
                set
                {
                   
                    this["total_amount"] = value;
                }
            }
            
            
            public string status
            {
                get
                {
                    return Convert.ToString(this["status"]);
                }
                set
                {
                   
                    this["status"] = value;
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


using System;
using System.Reflection;

namespace legr3
{
    [Label("Invoice")]
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


            [Label("Invoice ID")]
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
            
            [Label("Customer")]
            public long customer_id
            {
                get
                {
                    return Convert.ToInt64(this["customer_id"].ToString());
                }
                set
                {
                   
                    this["customer_id"] = value;
                }
            }
            
            [Label("Organization")]
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
            
            [Label("Number")]
            public long invoice_number
            {
                get
                {
                    return Convert.ToInt64(this["invoice_number"].ToString());
                }
                set
                {
                   
                    this["invoice_number"] = value;
                }
            }
            
            [Label("Invoice Date")]
            public DateTime invoice_date
            {
                get
                {
                    return Convert.ToDateTime(this["invoice_date"].ToString());
                }
                set
                {
                   
                    this["invoice_date"] = value;
                }
            }
            
            [Label("Due Date")]
            public DateTime due_date
            {
                get
                {
                    return Convert.ToDateTime(this["due_date"].ToString());
                }
                set
                {
                   
                    this["due_date"] = value;
                }
            }
            
            [Label("Total Amount")]
            public object total_amount
            {
                get
                {
                    return Convert.ToDouble(this["total_amount"].ToString());
                }
                set
                {
                   
                    this["total_amount"] = value;
                }
            }
            
            [Label("Status")]
            public string status
            {
                get
                {
                    return Convert.ToString(this["status"].ToString());
                }
                set
                {
                   
                    this["status"] = value;
                }
            }
            
            [Label("Created")]
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

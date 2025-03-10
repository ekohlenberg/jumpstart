
using System;
using System.Reflection;

namespace legr3
{
    [Label("Invoice Items")]
    public partial class InvoiceItem : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "InvoiceItem";
            tableName = "app.invoice_item";
            tableBaseName = "invoice_item";
            auditTableName = "audit.app_invoice_item";

        }


            [Label("Invoice Item ID")]
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
            
            [Label("Invoice ID")]
            public long invoice_id
            {
                get
                {
                    return Convert.ToInt64(this["invoice_id"]);
                }
                set
                {
                   
                    this["invoice_id"] = value;
                }
            }
            
            [Label("Description")]
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
            
            [Label("Quantity")]
            public int quantity
            {
                get
                {
                    return Convert.ToInt32(this["quantity"]);
                }
                set
                {
                   
                    this["quantity"] = value;
                }
            }
            
            [Label("Unit Price")]
            public object unit_price
            {
                get
                {
                    return Convert.ToDouble(this["unit_price"]);
                }
                set
                {
                   
                    this["unit_price"] = value;
                }
            }
            
            [Label("Total Amount")]
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
            
            [Label("Active")]
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
            
            [Label("Created By")]
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
            
            [Label("Last Updated")]
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
            
            [Label("Last Updated By")]
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
            
            [Label("Version")]
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

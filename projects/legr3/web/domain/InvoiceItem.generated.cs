
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
                    long _id;

                             _id = default(long);
                                                 
                    if(this.ContainsKey("id"))
                    {
                       _id = Convert.ToInt64(this["id"].ToString());
                    }
                    return _id;
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
                    long _invoice_id;

                             _invoice_id = default(long);
                                                 
                    if(this.ContainsKey("invoice_id"))
                    {
                       _invoice_id = Convert.ToInt64(this["invoice_id"].ToString());
                    }
                    return _invoice_id;
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
                    string _description;

                            _description = string.Empty;
                                                
                    if(this.ContainsKey("description"))
                    {
                       _description = Convert.ToString(this["description"].ToString());
                    }
                    return _description;
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
                    int _quantity;

                             _quantity = default(int);
                                                 
                    if(this.ContainsKey("quantity"))
                    {
                       _quantity = Convert.ToInt32(this["quantity"].ToString());
                    }
                    return _quantity;
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
                    object _unit_price;

                             _unit_price = default(object);
                                                 
                    if(this.ContainsKey("unit_price"))
                    {
                       _unit_price = Convert.ToDouble(this["unit_price"].ToString());
                    }
                    return _unit_price;
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
                    object _total_amount;

                             _total_amount = default(object);
                                                 
                    if(this.ContainsKey("total_amount"))
                    {
                       _total_amount = Convert.ToDouble(this["total_amount"].ToString());
                    }
                    return _total_amount;
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
                    int _is_active;

                             _is_active = default(int);
                                                 
                    if(this.ContainsKey("is_active"))
                    {
                       _is_active = Convert.ToInt32(this["is_active"].ToString());
                    }
                    return _is_active;
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
                    string _created_by;

                            _created_by = string.Empty;
                                                
                    if(this.ContainsKey("created_by"))
                    {
                       _created_by = Convert.ToString(this["created_by"].ToString());
                    }
                    return _created_by;
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
                    DateTime _last_updated;

                             _last_updated = default(DateTime);
                                                 
                    if(this.ContainsKey("last_updated"))
                    {
                       _last_updated = Convert.ToDateTime(this["last_updated"].ToString());
                    }
                    return _last_updated;
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
                    string _last_updated_by;

                            _last_updated_by = string.Empty;
                                                
                    if(this.ContainsKey("last_updated_by"))
                    {
                       _last_updated_by = Convert.ToString(this["last_updated_by"].ToString());
                    }
                    return _last_updated_by;
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
                    int _version;

                             _version = default(int);
                                                 
                    if(this.ContainsKey("version"))
                    {
                       _version = Convert.ToInt32(this["version"].ToString());
                    }
                    return _version;
                }
                set
                {
                   
                    this["version"] = value;
                }
            }
                }
}

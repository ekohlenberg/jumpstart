
using System;
using System.Reflection;

namespace legr3
{
    [Label("Payment")]
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


            [Label("Payment ID")]
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
            
            [Label("Organization ID")]
            public long org_id
            {
                get
                {
                    long _org_id;

                             _org_id = default(long);
                                                 
                    if(this.ContainsKey("org_id"))
                    {
                       _org_id = Convert.ToInt64(this["org_id"].ToString());
                    }
                    return _org_id;
                }
                set
                {
                   
                    this["org_id"] = value;
                }
            }
            
            [Label("Payment Date")]
            public DateTime payment_date
            {
                get
                {
                    DateTime _payment_date;

                             _payment_date = default(DateTime);
                                                 
                    if(this.ContainsKey("payment_date"))
                    {
                       _payment_date = Convert.ToDateTime(this["payment_date"].ToString());
                    }
                    return _payment_date;
                }
                set
                {
                   
                    this["payment_date"] = value;
                }
            }
            
            [Label("Amount")]
            public object amount
            {
                get
                {
                    object _amount;

                             _amount = default(object);
                                                 
                    if(this.ContainsKey("amount"))
                    {
                       _amount = Convert.ToDouble(this["amount"].ToString());
                    }
                    return _amount;
                }
                set
                {
                   
                    this["amount"] = value;
                }
            }
            
            [Label("Payment Method")]
            public string payment_method
            {
                get
                {
                    string _payment_method;

                            _payment_method = string.Empty;
                                                
                    if(this.ContainsKey("payment_method"))
                    {
                       _payment_method = Convert.ToString(this["payment_method"].ToString());
                    }
                    return _payment_method;
                }
                set
                {
                   
                    this["payment_method"] = value;
                }
            }
            
            [Label("Created Date")]
            public DateTime created_date
            {
                get
                {
                    DateTime _created_date;

                             _created_date = default(DateTime);
                                                 
                    if(this.ContainsKey("created_date"))
                    {
                       _created_date = Convert.ToDateTime(this["created_date"].ToString());
                    }
                    return _created_date;
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

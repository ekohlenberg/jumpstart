
using System;
using System.Reflection;

namespace legr3
{
    [Label("Customer")]
    public partial class Customer : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Customer";
            tableName = "app.customer";
            tableBaseName = "customer";
            auditTableName = "audit.app_customer";


            rwk.Add("org_id");
            
            rwk.Add("customer_name");
                    }


            [Label("Customer ID")]
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
            
            [Label("Name")]
            public string customer_name
            {
                get
                {
                    string _customer_name;

                            _customer_name = string.Empty;
                                                
                    if(this.ContainsKey("customer_name"))
                    {
                       _customer_name = Convert.ToString(this["customer_name"].ToString());
                    }
                    return _customer_name;
                }
                set
                {
                   
                    this["customer_name"] = value;
                }
            }
            
            [Label("First")]
            public string first_name
            {
                get
                {
                    string _first_name;

                            _first_name = string.Empty;
                                                
                    if(this.ContainsKey("first_name"))
                    {
                       _first_name = Convert.ToString(this["first_name"].ToString());
                    }
                    return _first_name;
                }
                set
                {
                   
                    this["first_name"] = value;
                }
            }
            
            [Label("Last")]
            public string last_name
            {
                get
                {
                    string _last_name;

                            _last_name = string.Empty;
                                                
                    if(this.ContainsKey("last_name"))
                    {
                       _last_name = Convert.ToString(this["last_name"].ToString());
                    }
                    return _last_name;
                }
                set
                {
                   
                    this["last_name"] = value;
                }
            }
            
            [Label("Email")]
            public string email
            {
                get
                {
                    string _email;

                            _email = string.Empty;
                                                
                    if(this.ContainsKey("email"))
                    {
                       _email = Convert.ToString(this["email"].ToString());
                    }
                    return _email;
                }
                set
                {
                   
                    this["email"] = value;
                }
            }
            
            [Label("Phone")]
            public string phone
            {
                get
                {
                    string _phone;

                            _phone = string.Empty;
                                                
                    if(this.ContainsKey("phone"))
                    {
                       _phone = Convert.ToString(this["phone"].ToString());
                    }
                    return _phone;
                }
                set
                {
                   
                    this["phone"] = value;
                }
            }
            
            [Label("Billing Address")]
            public string billing_address
            {
                get
                {
                    string _billing_address;

                            _billing_address = string.Empty;
                                                
                    if(this.ContainsKey("billing_address"))
                    {
                       _billing_address = Convert.ToString(this["billing_address"].ToString());
                    }
                    return _billing_address;
                }
                set
                {
                   
                    this["billing_address"] = value;
                }
            }
            
            [Label("Shipping Address")]
            public string shipping_address
            {
                get
                {
                    string _shipping_address;

                            _shipping_address = string.Empty;
                                                
                    if(this.ContainsKey("shipping_address"))
                    {
                       _shipping_address = Convert.ToString(this["shipping_address"].ToString());
                    }
                    return _shipping_address;
                }
                set
                {
                   
                    this["shipping_address"] = value;
                }
            }
            
            [Label("Created")]
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

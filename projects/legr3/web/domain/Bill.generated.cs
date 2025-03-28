
using System;
using System.Reflection;

namespace legr3
{
    [Label("Bill")]
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


            [Label("Bill ID")]
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
            
            [Label("Vendor ")]
            public long vendor_id
            {
                get
                {
                    long _vendor_id;

                             _vendor_id = default(long);
                                                 
                    if(this.ContainsKey("vendor_id"))
                    {
                       _vendor_id = Convert.ToInt64(this["vendor_id"].ToString());
                    }
                    return _vendor_id;
                }
                set
                {
                   
                    this["vendor_id"] = value;
                }
            }
            
            [Label("Organization")]
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
            
            [Label("Number")]
            public long bill_number
            {
                get
                {
                    long _bill_number;

                             _bill_number = default(long);
                                                 
                    if(this.ContainsKey("bill_number"))
                    {
                       _bill_number = Convert.ToInt64(this["bill_number"].ToString());
                    }
                    return _bill_number;
                }
                set
                {
                   
                    this["bill_number"] = value;
                }
            }
            
            [Label("Bill Date")]
            public DateTime bill_date
            {
                get
                {
                    DateTime _bill_date;

                             _bill_date = default(DateTime);
                                                 
                    if(this.ContainsKey("bill_date"))
                    {
                       _bill_date = Convert.ToDateTime(this["bill_date"].ToString());
                    }
                    return _bill_date;
                }
                set
                {
                   
                    this["bill_date"] = value;
                }
            }
            
            [Label("Due Date")]
            public DateTime due_date
            {
                get
                {
                    DateTime _due_date;

                             _due_date = default(DateTime);
                                                 
                    if(this.ContainsKey("due_date"))
                    {
                       _due_date = Convert.ToDateTime(this["due_date"].ToString());
                    }
                    return _due_date;
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
            
            [Label("Status")]
            public string status
            {
                get
                {
                    string _status;

                            _status = string.Empty;
                                                
                    if(this.ContainsKey("status"))
                    {
                       _status = Convert.ToString(this["status"].ToString());
                    }
                    return _status;
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

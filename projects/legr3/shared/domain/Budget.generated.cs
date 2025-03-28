
using System;
using System.Reflection;

namespace legr3
{
    [Label("Budget")]
    public partial class Budget : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Budget";
            tableName = "app.budget";
            tableBaseName = "budget";
            auditTableName = "audit.app_budget";


            rwk.Add("org_id");
            
            rwk.Add("category_id");
                    }


            [Label("Budget ID")]
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
            
            [Label("Category ID")]
            public long category_id
            {
                get
                {
                    long _category_id;

                             _category_id = default(long);
                                                 
                    if(this.ContainsKey("category_id"))
                    {
                       _category_id = Convert.ToInt64(this["category_id"].ToString());
                    }
                    return _category_id;
                }
                set
                {
                   
                    this["category_id"] = value;
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
            
            [Label("Start Date")]
            public DateTime start_date
            {
                get
                {
                    DateTime _start_date;

                             _start_date = default(DateTime);
                                                 
                    if(this.ContainsKey("start_date"))
                    {
                       _start_date = Convert.ToDateTime(this["start_date"].ToString());
                    }
                    return _start_date;
                }
                set
                {
                   
                    this["start_date"] = value;
                }
            }
            
            [Label("End Date")]
            public DateTime end_date
            {
                get
                {
                    DateTime _end_date;

                             _end_date = default(DateTime);
                                                 
                    if(this.ContainsKey("end_date"))
                    {
                       _end_date = Convert.ToDateTime(this["end_date"].ToString());
                    }
                    return _end_date;
                }
                set
                {
                   
                    this["end_date"] = value;
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

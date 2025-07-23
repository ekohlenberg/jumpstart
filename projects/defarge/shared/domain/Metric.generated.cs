
using System;
using System.Reflection;

namespace defarge
{
    [Label("Metric")]
    public partial class Metric : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Metric";
            tableName = "app.metric";
            tableBaseName = "metric";
            auditTableName = "audit.app_metric";


            rwk.Add("category_id");
                    }


            [Label("ID")]
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
            
            [Label("Name")]
            public string name
            {
                get
                {
                    string _name;

                            _name = string.Empty;
                                                
                    if(this.ContainsKey("name"))
                    {
                       _name = Convert.ToString(this["name"].ToString());
                    }
                    return _name;
                }
                set
                {
                   
                    this["name"] = value;
                }
            }
            
            [Label("Category")]
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
            
            [Label("Unit")]
            public long uom_id
            {
                get
                {
                    long _uom_id;

                             _uom_id = default(long);
                                                 
                    if(this.ContainsKey("uom_id"))
                    {
                       _uom_id = Convert.ToInt64(this["uom_id"].ToString());
                    }
                    return _uom_id;
                }
                set
                {
                   
                    this["uom_id"] = value;
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

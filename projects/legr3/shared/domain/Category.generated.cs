
using System;
using System.Reflection;

namespace legr3
{
    [Label("Category")]
    public partial class Category : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Category";
            tableName = "app.category";
            tableBaseName = "category";
            auditTableName = "audit.app_category";


            rwk.Add("org_id");
            
            rwk.Add("category_name");
                    }


            [Label("Category ID")]
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
            public string category_name
            {
                get
                {
                    string _category_name;

                            _category_name = string.Empty;
                                                
                    if(this.ContainsKey("category_name"))
                    {
                       _category_name = Convert.ToString(this["category_name"].ToString());
                    }
                    return _category_name;
                }
                set
                {
                   
                    this["category_name"] = value;
                }
            }
            
            [Label("Category Type")]
            public string category_type
            {
                get
                {
                    string _category_type;

                            _category_type = string.Empty;
                                                
                    if(this.ContainsKey("category_type"))
                    {
                       _category_type = Convert.ToString(this["category_type"].ToString());
                    }
                    return _category_type;
                }
                set
                {
                   
                    this["category_type"] = value;
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

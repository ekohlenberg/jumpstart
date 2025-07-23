
using System;
using System.Reflection;

namespace defarge
{
    [Label("Metric Resource Map")]
    public partial class MetricResourceMap : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "MetricResourceMap";
            tableName = "app.metric_resource_map";
            tableBaseName = "metric_resource_map";
            auditTableName = "audit.app_metric_resource_map";


            rwk.Add("resource_id");
            
            rwk.Add("metric_id");
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
            
            [Label("Resource")]
            public long resource_id
            {
                get
                {
                    long _resource_id;

                             _resource_id = default(long);
                                                 
                    if(this.ContainsKey("resource_id"))
                    {
                       _resource_id = Convert.ToInt64(this["resource_id"].ToString());
                    }
                    return _resource_id;
                }
                set
                {
                   
                    this["resource_id"] = value;
                }
            }
            
            [Label("Metric")]
            public long metric_id
            {
                get
                {
                    long _metric_id;

                             _metric_id = default(long);
                                                 
                    if(this.ContainsKey("metric_id"))
                    {
                       _metric_id = Convert.ToInt64(this["metric_id"].ToString());
                    }
                    return _metric_id;
                }
                set
                {
                   
                    this["metric_id"] = value;
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

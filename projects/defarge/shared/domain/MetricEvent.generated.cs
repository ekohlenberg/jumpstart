
using System;
using System.Reflection;

namespace defarge
{
    [Label("Metric Event")]
    public partial class MetricEvent : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "MetricEvent";
            tableName = "app.metric_event";
            tableBaseName = "metric_event";
            auditTableName = "audit.app_metric_event";


            rwk.Add("metric_id");
            
            rwk.Add("event_time");
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
            
            [Label("Event Time")]
            public DateTime event_time
            {
                get
                {
                    DateTime _event_time;

                             _event_time = default(DateTime);
                                                 
                    if(this.ContainsKey("event_time"))
                    {
                       _event_time = Convert.ToDateTime(this["event_time"].ToString());
                    }
                    return _event_time;
                }
                set
                {
                   
                    this["event_time"] = value;
                }
            }
            
            [Label("Value")]
            public object value
            {
                get
                {
                    object _value;

                             _value = default(object);
                                                 
                    if(this.ContainsKey("value"))
                    {
                       _value = Convert.ToDecimal(this["value"].ToString());
                    }
                    return _value;
                }
                set
                {
                   
                    this["value"] = value;
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

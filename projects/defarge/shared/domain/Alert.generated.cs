
using System;
using System.Reflection;

namespace defarge
{
    [Label("Alert")]
    public partial class Alert : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Alert";
            tableName = "app.alert";
            tableBaseName = "alert";
            auditTableName = "audit.app_alert";

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
            
            [Label("Alert")]
            public long alert_rule_id
            {
                get
                {
                    long _alert_rule_id;

                             _alert_rule_id = default(long);
                                                 
                    if(this.ContainsKey("alert_rule_id"))
                    {
                       _alert_rule_id = Convert.ToInt64(this["alert_rule_id"].ToString());
                    }
                    return _alert_rule_id;
                }
                set
                {
                   
                    this["alert_rule_id"] = value;
                }
            }
            
            [Label("Metric")]
            public long metric_event_id
            {
                get
                {
                    long _metric_event_id;

                             _metric_event_id = default(long);
                                                 
                    if(this.ContainsKey("metric_event_id"))
                    {
                       _metric_event_id = Convert.ToInt64(this["metric_event_id"].ToString());
                    }
                    return _metric_event_id;
                }
                set
                {
                   
                    this["metric_event_id"] = value;
                }
            }
            
            [Label("Triggered")]
            public DateTime triggered_at
            {
                get
                {
                    DateTime _triggered_at;

                             _triggered_at = default(DateTime);
                                                 
                    if(this.ContainsKey("triggered_at"))
                    {
                       _triggered_at = Convert.ToDateTime(this["triggered_at"].ToString());
                    }
                    return _triggered_at;
                }
                set
                {
                   
                    this["triggered_at"] = value;
                }
            }
            
            [Label("Resolved")]
            public DateTime resolved_at
            {
                get
                {
                    DateTime _resolved_at;

                             _resolved_at = default(DateTime);
                                                 
                    if(this.ContainsKey("resolved_at"))
                    {
                       _resolved_at = Convert.ToDateTime(this["resolved_at"].ToString());
                    }
                    return _resolved_at;
                }
                set
                {
                   
                    this["resolved_at"] = value;
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

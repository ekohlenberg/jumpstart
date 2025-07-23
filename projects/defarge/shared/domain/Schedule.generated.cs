
using System;
using System.Reflection;

namespace defarge
{
    [Label("Schedule")]
    public partial class Schedule : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Schedule";
            tableName = "core.schedule";
            tableBaseName = "schedule";
            auditTableName = "audit.core_schedule";


            rwk.Add("cron_expression");
                    }


            [Label("")]
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
            
            [Label("")]
            public string cron_expression
            {
                get
                {
                    string _cron_expression;

                            _cron_expression = string.Empty;
                                                
                    if(this.ContainsKey("cron_expression"))
                    {
                       _cron_expression = Convert.ToString(this["cron_expression"].ToString());
                    }
                    return _cron_expression;
                }
                set
                {
                   
                    this["cron_expression"] = value;
                }
            }
            
            [Label("")]
            public DateTime next_run_time
            {
                get
                {
                    DateTime _next_run_time;

                             _next_run_time = default(DateTime);
                                                 
                    if(this.ContainsKey("next_run_time"))
                    {
                       _next_run_time = Convert.ToDateTime(this["next_run_time"].ToString());
                    }
                    return _next_run_time;
                }
                set
                {
                   
                    this["next_run_time"] = value;
                }
            }
            
            [Label("")]
            public DateTime last_run_time
            {
                get
                {
                    DateTime _last_run_time;

                             _last_run_time = default(DateTime);
                                                 
                    if(this.ContainsKey("last_run_time"))
                    {
                       _last_run_time = Convert.ToDateTime(this["last_run_time"].ToString());
                    }
                    return _last_run_time;
                }
                set
                {
                   
                    this["last_run_time"] = value;
                }
            }
            
            [Label("")]
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


using System;
using System.Reflection;

namespace defarge
{
    [Label("Execution Log")]
    public partial class Execution : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Execution";
            tableName = "core.execution";
            tableBaseName = "execution";
            auditTableName = "audit.core_execution";


            rwk.Add("token");
            
            rwk.Add("process_id");
            
            rwk.Add("start_time");
            
            rwk.Add("end_time");
                    }


            [Label("Execution ID")]
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
            
            [Label("Token")]
            public string token
            {
                get
                {
                    string _token;

                            _token = string.Empty;
                                                
                    if(this.ContainsKey("token"))
                    {
                       _token = Convert.ToString(this["token"].ToString());
                    }
                    return _token;
                }
                set
                {
                   
                    this["token"] = value;
                }
            }
            
            [Label("Process")]
            public long process_id
            {
                get
                {
                    long _process_id;

                             _process_id = default(long);
                                                 
                    if(this.ContainsKey("process_id"))
                    {
                       _process_id = Convert.ToInt64(this["process_id"].ToString());
                    }
                    return _process_id;
                }
                set
                {
                   
                    this["process_id"] = value;
                }
            }
            
            [Label("Start Time")]
            public DateTime start_time
            {
                get
                {
                    DateTime _start_time;

                             _start_time = default(DateTime);
                                                 
                    if(this.ContainsKey("start_time"))
                    {
                       _start_time = Convert.ToDateTime(this["start_time"].ToString());
                    }
                    return _start_time;
                }
                set
                {
                   
                    this["start_time"] = value;
                }
            }
            
            [Label("End Time")]
            public DateTime end_time
            {
                get
                {
                    DateTime _end_time;

                             _end_time = default(DateTime);
                                                 
                    if(this.ContainsKey("end_time"))
                    {
                       _end_time = Convert.ToDateTime(this["end_time"].ToString());
                    }
                    return _end_time;
                }
                set
                {
                   
                    this["end_time"] = value;
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
            
            [Label("Log Output")]
            public string log_output
            {
                get
                {
                    string _log_output;

                            _log_output = string.Empty;
                                                
                    if(this.ContainsKey("log_output"))
                    {
                       _log_output = Convert.ToString(this["log_output"].ToString());
                    }
                    return _log_output;
                }
                set
                {
                   
                    this["log_output"] = value;
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

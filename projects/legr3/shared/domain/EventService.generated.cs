
using System;
using System.Reflection;

namespace legr3
{
    [Label("Events")]
    public partial class EventService : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "EventService";
            tableName = "core.event_service";
            tableBaseName = "event_service";
            auditTableName = "audit.core_event_service";


            rwk.Add("event_type");
            
            rwk.Add("objectname_filter");
            
            rwk.Add("methodname_filter");
            
            rwk.Add("script_id");
                    }


            [Label("Event ID")]
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
            
            [Label("Event Type")]
            public string event_type
            {
                get
                {
                    string _event_type;

                            _event_type = string.Empty;
                                                
                    if(this.ContainsKey("event_type"))
                    {
                       _event_type = Convert.ToString(this["event_type"].ToString());
                    }
                    return _event_type;
                }
                set
                {
                   
                    this["event_type"] = value;
                }
            }
            
            [Label("Object Filter")]
            public string objectname_filter
            {
                get
                {
                    string _objectname_filter;

                            _objectname_filter = string.Empty;
                                                
                    if(this.ContainsKey("objectname_filter"))
                    {
                       _objectname_filter = Convert.ToString(this["objectname_filter"].ToString());
                    }
                    return _objectname_filter;
                }
                set
                {
                   
                    this["objectname_filter"] = value;
                }
            }
            
            [Label("Method Filter")]
            public string methodname_filter
            {
                get
                {
                    string _methodname_filter;

                            _methodname_filter = string.Empty;
                                                
                    if(this.ContainsKey("methodname_filter"))
                    {
                       _methodname_filter = Convert.ToString(this["methodname_filter"].ToString());
                    }
                    return _methodname_filter;
                }
                set
                {
                   
                    this["methodname_filter"] = value;
                }
            }
            
            [Label("Script ID")]
            public long script_id
            {
                get
                {
                    long _script_id;

                             _script_id = default(long);
                                                 
                    if(this.ContainsKey("script_id"))
                    {
                       _script_id = Convert.ToInt64(this["script_id"].ToString());
                    }
                    return _script_id;
                }
                set
                {
                   
                    this["script_id"] = value;
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

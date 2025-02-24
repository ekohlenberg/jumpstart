
using System;
using System.Reflection;

namespace legr3
{
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


            
            public long id
            {
                get
                {
                    return Convert.ToInt64(this["id"]);
                }
                set
                {
                   
                    this["id"] = value;
                }
            }
            
            
            public string event_type
            {
                get
                {
                    return Convert.ToString(this["event_type"]);
                }
                set
                {
                   
                    this["event_type"] = value;
                }
            }
            
            
            public string objectname_filter
            {
                get
                {
                    return Convert.ToString(this["objectname_filter"]);
                }
                set
                {
                   
                    this["objectname_filter"] = value;
                }
            }
            
            
            public string methodname_filter
            {
                get
                {
                    return Convert.ToString(this["methodname_filter"]);
                }
                set
                {
                   
                    this["methodname_filter"] = value;
                }
            }
            
            
            public long script_id
            {
                get
                {
                    return Convert.ToInt64(this["script_id"]);
                }
                set
                {
                   
                    this["script_id"] = value;
                }
            }
            
            
            public int is_active
            {
                get
                {
                    return Convert.ToInt32(this["is_active"]);
                }
                set
                {
                   
                    this["is_active"] = value;
                }
            }
            
            
            public string created_by
            {
                get
                {
                    return Convert.ToString(this["created_by"]);
                }
                set
                {
                   
                    this["created_by"] = value;
                }
            }
            
            
            public DateTime last_updated
            {
                get
                {
                    return Convert.ToDateTime(this["last_updated"]);
                }
                set
                {
                   
                    this["last_updated"] = value;
                }
            }
            
            
            public string last_updated_by
            {
                get
                {
                    return Convert.ToString(this["last_updated_by"]);
                }
                set
                {
                   
                    this["last_updated_by"] = value;
                }
            }
            
            
            public int version
            {
                get
                {
                    return Convert.ToInt32(this["version"]);
                }
                set
                {
                   
                    this["version"] = value;
                }
            }
                }
}

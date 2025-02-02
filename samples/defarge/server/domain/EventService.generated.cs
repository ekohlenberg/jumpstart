
using System;
using System.Reflection;

namespace defarge
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
                    return Convert.ToInt64(getPropValue("id"));
                }
                set
                {
                    setPropValue("id", value);
                }
            }
            
            public string event_type
            {
                get
                {
                    return Convert.ToString(getPropValue("event_type"));
                }
                set
                {
                    setPropValue("event_type", value);
                }
            }
            
            public string objectname_filter
            {
                get
                {
                    return Convert.ToString(getPropValue("objectname_filter"));
                }
                set
                {
                    setPropValue("objectname_filter", value);
                }
            }
            
            public string methodname_filter
            {
                get
                {
                    return Convert.ToString(getPropValue("methodname_filter"));
                }
                set
                {
                    setPropValue("methodname_filter", value);
                }
            }
            
            public long script_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("script_id"));
                }
                set
                {
                    setPropValue("script_id", value);
                }
            }
            
            public int is_active
            {
                get
                {
                    return Convert.ToInt32(getPropValue("is_active"));
                }
                set
                {
                    setPropValue("is_active", value);
                }
            }
            
            public string created_by
            {
                get
                {
                    return Convert.ToString(getPropValue("created_by"));
                }
                set
                {
                    setPropValue("created_by", value);
                }
            }
            
            public DateTime last_updated
            {
                get
                {
                    return Convert.ToDateTime(getPropValue("last_updated"));
                }
                set
                {
                    setPropValue("last_updated", value);
                }
            }
            
            public string last_updated_by
            {
                get
                {
                    return Convert.ToString(getPropValue("last_updated_by"));
                }
                set
                {
                    setPropValue("last_updated_by", value);
                }
            }
            
            public int version
            {
                get
                {
                    return Convert.ToInt32(getPropValue("version"));
                }
                set
                {
                    setPropValue("version", value);
                }
            }
                }
}

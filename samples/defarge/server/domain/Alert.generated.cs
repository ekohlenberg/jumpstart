
using System;
using System.Reflection;

namespace defarge
{
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
            
            public long alert_rule_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("alert_rule_id"));
                }
                set
                {
                    setPropValue("alert_rule_id", value);
                }
            }
            
            public long metric_event_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("metric_event_id"));
                }
                set
                {
                    setPropValue("metric_event_id", value);
                }
            }
            
            public DateTime triggered_at
            {
                get
                {
                    return Convert.ToDateTime(getPropValue("triggered_at"));
                }
                set
                {
                    setPropValue("triggered_at", value);
                }
            }
            
            public DateTime resolved_at
            {
                get
                {
                    return Convert.ToDateTime(getPropValue("resolved_at"));
                }
                set
                {
                    setPropValue("resolved_at", value);
                }
            }
            
            public string status
            {
                get
                {
                    return Convert.ToString(getPropValue("status"));
                }
                set
                {
                    setPropValue("status", value);
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

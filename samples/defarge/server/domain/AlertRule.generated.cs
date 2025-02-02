
using System;
using System.Reflection;

namespace defarge
{
    public partial class AlertRule : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "AlertRule";
            tableName = "app.alert_rule";
            tableBaseName = "alert_rule";
            auditTableName = "audit.app_alert_rule";


            rwk.Add("metric_id");
            
            rwk.Add("name");
            
            rwk.Add("condition");
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
            
            public long metric_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("metric_id"));
                }
                set
                {
                    setPropValue("metric_id", value);
                }
            }
            
            public string name
            {
                get
                {
                    return Convert.ToString(getPropValue("name"));
                }
                set
                {
                    setPropValue("name", value);
                }
            }
            
            public string condition
            {
                get
                {
                    return Convert.ToString(getPropValue("condition"));
                }
                set
                {
                    setPropValue("condition", value);
                }
            }
            
            public object threshold
            {
                get
                {
                    return Convert.ToDouble(getPropValue("threshold"));
                }
                set
                {
                    setPropValue("threshold", value);
                }
            }
            
            public string recipients
            {
                get
                {
                    return Convert.ToString(getPropValue("recipients"));
                }
                set
                {
                    setPropValue("recipients", value);
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

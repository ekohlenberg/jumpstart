
using System;
using System.Reflection;

namespace defarge
{
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
            
            public long resource_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("resource_id"));
                }
                set
                {
                    setPropValue("resource_id", value);
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

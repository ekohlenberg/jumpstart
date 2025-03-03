
using System;
using System.Reflection;

namespace defarge
{
    public partial class Metric : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Metric";
            tableName = "app.metric";
            tableBaseName = "metric";
            auditTableName = "audit.app_metric";


            rwk.Add("category_id");
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
            
            public long category_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("category_id"));
                }
                set
                {
                    setPropValue("category_id", value);
                }
            }
            
            public long uom_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("uom_id"));
                }
                set
                {
                    setPropValue("uom_id", value);
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

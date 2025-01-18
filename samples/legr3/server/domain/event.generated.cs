
using System;
using System.Reflection;

namespace 
{
    public partial class Event : BaseObject
    {
        protected void initialize()
        {
            // Default initializer
            tableName = "core.event";
            tableBaseName = "event";
            auditTableName = "audit.core_event";

rwk.Add("object");rwk.Add("method");rwk.Add("script_id");        }


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
            
            public string object
            {
                get
                {
                    return Convert.ToString(getPropValue("object"));
                }
                set
                {
                    setPropValue("object", value);
                }
            }
            
            public string method
            {
                get
                {
                    return Convert.ToString(getPropValue("method"));
                }
                set
                {
                    setPropValue("method", value);
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

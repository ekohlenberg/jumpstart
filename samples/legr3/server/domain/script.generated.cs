
using System;
using System.Reflection;

namespace legr3
{
    public partial class Script : BaseObject
    {
        protected void initialize()
        {
            // Default initializer
            tableName = "core.script";
            tableBaseName = "script";
            auditTableName = "audit.core_script";

rwk.Add("name");        }


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
            
            public string source
            {
                get
                {
                    return Convert.ToString(getPropValue("source"));
                }
                set
                {
                    setPropValue("source", value);
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

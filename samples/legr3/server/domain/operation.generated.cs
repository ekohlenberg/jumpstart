
using System;
using System.Reflection;

namespace legr3
{
    public partial class Operation : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            tableName = "sec.operation";
            tableBaseName = "operation";
            auditTableName = "audit.sec_operation";

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
            
            public string objectname
            {
                get
                {
                    return Convert.ToString(getPropValue("objectname"));
                }
                set
                {
                    setPropValue("objectname", value);
                }
            }
            
            public string methodname
            {
                get
                {
                    return Convert.ToString(getPropValue("methodname"));
                }
                set
                {
                    setPropValue("methodname", value);
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


using System;
using System.Reflection;

namespace defarge
{
    public partial class Resource : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Resource";
            tableName = "app.resource";
            tableBaseName = "resource";
            auditTableName = "audit.app_resource";


            rwk.Add("name");
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
            
            public long resource_type_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("resource_type_id"));
                }
                set
                {
                    setPropValue("resource_type_id", value);
                }
            }
            
            public string ip_address
            {
                get
                {
                    return Convert.ToString(getPropValue("ip_address"));
                }
                set
                {
                    setPropValue("ip_address", value);
                }
            }
            
            public string description
            {
                get
                {
                    return Convert.ToString(getPropValue("description"));
                }
                set
                {
                    setPropValue("description", value);
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

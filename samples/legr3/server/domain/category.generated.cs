
using System;
using System.Reflection;

namespace legr3
{
    public partial class Category : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            tableName = "app.category";
            tableBaseName = "category";
            auditTableName = "audit.app_category";

rwk.Add("org_id");rwk.Add("category_name");        }


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
            
            public long org_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("org_id"));
                }
                set
                {
                    setPropValue("org_id", value);
                }
            }
            
            public string category_name
            {
                get
                {
                    return Convert.ToString(getPropValue("category_name"));
                }
                set
                {
                    setPropValue("category_name", value);
                }
            }
            
            public string category_type
            {
                get
                {
                    return Convert.ToString(getPropValue("category_type"));
                }
                set
                {
                    setPropValue("category_type", value);
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

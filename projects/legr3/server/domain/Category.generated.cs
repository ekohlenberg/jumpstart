
using System;
using System.Reflection;

namespace legr3
{
    public partial class Category : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Category";
            tableName = "app.category";
            tableBaseName = "category";
            auditTableName = "audit.app_category";


            rwk.Add("org_id");
            
            rwk.Add("category_name");
                    }


            
            public long id
            {
                get
                {
                    return Convert.ToInt64(this["id"]);
                }
                set
                {
                   
                    this["id"] = value;
                }
            }
            
            
            public long org_id
            {
                get
                {
                    return Convert.ToInt64(this["org_id"]);
                }
                set
                {
                   
                    this["org_id"] = value;
                }
            }
            
            
            public string category_name
            {
                get
                {
                    return Convert.ToString(this["category_name"]);
                }
                set
                {
                   
                    this["category_name"] = value;
                }
            }
            
            
            public string category_type
            {
                get
                {
                    return Convert.ToString(this["category_type"]);
                }
                set
                {
                   
                    this["category_type"] = value;
                }
            }
            
            
            public int is_active
            {
                get
                {
                    return Convert.ToInt32(this["is_active"]);
                }
                set
                {
                   
                    this["is_active"] = value;
                }
            }
            
            
            public string created_by
            {
                get
                {
                    return Convert.ToString(this["created_by"]);
                }
                set
                {
                   
                    this["created_by"] = value;
                }
            }
            
            
            public DateTime last_updated
            {
                get
                {
                    return Convert.ToDateTime(this["last_updated"]);
                }
                set
                {
                   
                    this["last_updated"] = value;
                }
            }
            
            
            public string last_updated_by
            {
                get
                {
                    return Convert.ToString(this["last_updated_by"]);
                }
                set
                {
                   
                    this["last_updated_by"] = value;
                }
            }
            
            
            public int version
            {
                get
                {
                    return Convert.ToInt32(this["version"]);
                }
                set
                {
                   
                    this["version"] = value;
                }
            }
                }
}


using System;
using System.Reflection;

namespace legr3
{
    [Label("Category")]
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


            [Label("Category ID")]
            public long id
            {
                get
                {
                    return Convert.ToInt64(this["id"].ToString());
                }
                set
                {
                   
                    this["id"] = value;
                }
            }
            
            [Label("Organization ID")]
            public long org_id
            {
                get
                {
                    return Convert.ToInt64(this["org_id"].ToString());
                }
                set
                {
                   
                    this["org_id"] = value;
                }
            }
            
            [Label("Name")]
            public string category_name
            {
                get
                {
                    return Convert.ToString(this["category_name"].ToString());
                }
                set
                {
                   
                    this["category_name"] = value;
                }
            }
            
            [Label("Category Type")]
            public string category_type
            {
                get
                {
                    return Convert.ToString(this["category_type"].ToString());
                }
                set
                {
                   
                    this["category_type"] = value;
                }
            }
            
            [Label("Active")]
            public int is_active
            {
                get
                {
                    return Convert.ToInt32(this["is_active"].ToString());
                }
                set
                {
                   
                    this["is_active"] = value;
                }
            }
            
            [Label("Created By")]
            public string created_by
            {
                get
                {
                    return Convert.ToString(this["created_by"].ToString());
                }
                set
                {
                   
                    this["created_by"] = value;
                }
            }
            
            [Label("Last Updated")]
            public DateTime last_updated
            {
                get
                {
                    return Convert.ToDateTime(this["last_updated"].ToString());
                }
                set
                {
                   
                    this["last_updated"] = value;
                }
            }
            
            [Label("Last Updated By")]
            public string last_updated_by
            {
                get
                {
                    return Convert.ToString(this["last_updated_by"].ToString());
                }
                set
                {
                   
                    this["last_updated_by"] = value;
                }
            }
            
            [Label("Version")]
            public int version
            {
                get
                {
                    return Convert.ToInt32(this["version"].ToString());
                }
                set
                {
                   
                    this["version"] = value;
                }
            }
                }
}

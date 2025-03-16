
using System;
using System.Reflection;

namespace legr3
{
    [Label("Budget")]
    public partial class Budget : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Budget";
            tableName = "app.budget";
            tableBaseName = "budget";
            auditTableName = "audit.app_budget";


            rwk.Add("org_id");
            
            rwk.Add("category_id");
                    }


            [Label("Budget ID")]
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
            
            [Label("Category ID")]
            public long category_id
            {
                get
                {
                    return Convert.ToInt64(this["category_id"].ToString());
                }
                set
                {
                   
                    this["category_id"] = value;
                }
            }
            
            [Label("Amount")]
            public object amount
            {
                get
                {
                    return Convert.ToDouble(this["amount"].ToString());
                }
                set
                {
                   
                    this["amount"] = value;
                }
            }
            
            [Label("Start Date")]
            public DateTime start_date
            {
                get
                {
                    return Convert.ToDateTime(this["start_date"].ToString());
                }
                set
                {
                   
                    this["start_date"] = value;
                }
            }
            
            [Label("End Date")]
            public DateTime end_date
            {
                get
                {
                    return Convert.ToDateTime(this["end_date"].ToString());
                }
                set
                {
                   
                    this["end_date"] = value;
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

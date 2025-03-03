
using System;
using System.Reflection;

namespace legr3
{
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
            
            
            public long category_id
            {
                get
                {
                    return Convert.ToInt64(this["category_id"]);
                }
                set
                {
                   
                    this["category_id"] = value;
                }
            }
            
            
            public object amount
            {
                get
                {
                    return Convert.ToDouble(this["amount"]);
                }
                set
                {
                   
                    this["amount"] = value;
                }
            }
            
            
            public DateTime start_date
            {
                get
                {
                    return Convert.ToDateTime(this["start_date"]);
                }
                set
                {
                   
                    this["start_date"] = value;
                }
            }
            
            
            public DateTime end_date
            {
                get
                {
                    return Convert.ToDateTime(this["end_date"]);
                }
                set
                {
                   
                    this["end_date"] = value;
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

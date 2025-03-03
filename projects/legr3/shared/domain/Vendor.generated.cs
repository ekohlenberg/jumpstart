
using System;
using System.Reflection;

namespace legr3
{
    [Label("Vendor")]
    public partial class Vendor : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Vendor";
            tableName = "app.vendor";
            tableBaseName = "vendor";
            auditTableName = "audit.app_vendor";


            rwk.Add("org_id");
            
            rwk.Add("vendor_name");
                    }


            [Label("Vendor ")]
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
            
            [Label("Organization")]
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
            
            [Label("Name")]
            public string vendor_name
            {
                get
                {
                    return Convert.ToString(this["vendor_name"]);
                }
                set
                {
                   
                    this["vendor_name"] = value;
                }
            }
            
            [Label("First")]
            public string first_name
            {
                get
                {
                    return Convert.ToString(this["first_name"]);
                }
                set
                {
                   
                    this["first_name"] = value;
                }
            }
            
            [Label("Last")]
            public string last_name
            {
                get
                {
                    return Convert.ToString(this["last_name"]);
                }
                set
                {
                   
                    this["last_name"] = value;
                }
            }
            
            [Label("Email")]
            public string email
            {
                get
                {
                    return Convert.ToString(this["email"]);
                }
                set
                {
                   
                    this["email"] = value;
                }
            }
            
            [Label("Phone")]
            public string phone
            {
                get
                {
                    return Convert.ToString(this["phone"]);
                }
                set
                {
                   
                    this["phone"] = value;
                }
            }
            
            [Label("Billing Address")]
            public string billing_address
            {
                get
                {
                    return Convert.ToString(this["billing_address"]);
                }
                set
                {
                   
                    this["billing_address"] = value;
                }
            }
            
            [Label("Created")]
            public DateTime created_date
            {
                get
                {
                    return Convert.ToDateTime(this["created_date"]);
                }
                set
                {
                   
                    this["created_date"] = value;
                }
            }
            
            [Label("Active")]
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
            
            [Label("Created By")]
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
            
            [Label("Last Updated")]
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
            
            [Label("Last Updated By")]
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
            
            [Label("Version")]
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

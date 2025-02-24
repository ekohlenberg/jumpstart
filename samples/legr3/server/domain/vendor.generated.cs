
using System;
using System.Reflection;

namespace legr3
{
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

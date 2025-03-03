
using System;
using System.Reflection;

namespace legr3
{
    [Label("Customer")]
    public partial class Customer : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Customer";
            tableName = "app.customer";
            tableBaseName = "customer";
            auditTableName = "audit.app_customer";


            rwk.Add("org_id");
            
            rwk.Add("customer_name");
                    }


            [Label("Customer ID")]
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
            
            [Label("Organization ID")]
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
            public string customer_name
            {
                get
                {
                    return Convert.ToString(this["customer_name"]);
                }
                set
                {
                   
                    this["customer_name"] = value;
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
            
            [Label("Shipping Address")]
            public string shipping_address
            {
                get
                {
                    return Convert.ToString(this["shipping_address"]);
                }
                set
                {
                   
                    this["shipping_address"] = value;
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

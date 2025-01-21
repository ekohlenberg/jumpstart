
using System;
using System.Reflection;

namespace legr3
{
    public partial class Customer : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            tableName = "app.customer";
            tableBaseName = "customer";
            auditTableName = "audit.app_customer";

rwk.Add("org_id");rwk.Add("customer_name");        }


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
            
            public string customer_name
            {
                get
                {
                    return Convert.ToString(getPropValue("customer_name"));
                }
                set
                {
                    setPropValue("customer_name", value);
                }
            }
            
            public string first_name
            {
                get
                {
                    return Convert.ToString(getPropValue("first_name"));
                }
                set
                {
                    setPropValue("first_name", value);
                }
            }
            
            public string last_name
            {
                get
                {
                    return Convert.ToString(getPropValue("last_name"));
                }
                set
                {
                    setPropValue("last_name", value);
                }
            }
            
            public string email
            {
                get
                {
                    return Convert.ToString(getPropValue("email"));
                }
                set
                {
                    setPropValue("email", value);
                }
            }
            
            public string phone
            {
                get
                {
                    return Convert.ToString(getPropValue("phone"));
                }
                set
                {
                    setPropValue("phone", value);
                }
            }
            
            public string billing_address
            {
                get
                {
                    return Convert.ToString(getPropValue("billing_address"));
                }
                set
                {
                    setPropValue("billing_address", value);
                }
            }
            
            public string shipping_address
            {
                get
                {
                    return Convert.ToString(getPropValue("shipping_address"));
                }
                set
                {
                    setPropValue("shipping_address", value);
                }
            }
            
            public DateTime created_date
            {
                get
                {
                    return Convert.ToDateTime(getPropValue("created_date"));
                }
                set
                {
                    setPropValue("created_date", value);
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


using System;
using System.Reflection;

namespace legr3
{
    [Label("Payment")]
    public partial class Payment : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Payment";
            tableName = "app.payment";
            tableBaseName = "payment";
            auditTableName = "audit.app_payment";

        }


            [Label("Payment ID")]
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
            
            [Label("Invoice ID")]
            public long invoice_id
            {
                get
                {
                    return Convert.ToInt64(this["invoice_id"].ToString());
                }
                set
                {
                   
                    this["invoice_id"] = value;
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
            
            [Label("Payment Date")]
            public DateTime payment_date
            {
                get
                {
                    return Convert.ToDateTime(this["payment_date"].ToString());
                }
                set
                {
                   
                    this["payment_date"] = value;
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
            
            [Label("Payment Method")]
            public string payment_method
            {
                get
                {
                    return Convert.ToString(this["payment_method"].ToString());
                }
                set
                {
                   
                    this["payment_method"] = value;
                }
            }
            
            [Label("Created Date")]
            public DateTime created_date
            {
                get
                {
                    return Convert.ToDateTime(this["created_date"].ToString());
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

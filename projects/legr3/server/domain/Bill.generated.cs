
using System;
using System.Reflection;

namespace legr3
{
    public partial class Bill : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Bill";
            tableName = "app.bill";
            tableBaseName = "bill";
            auditTableName = "audit.app_bill";

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
            
            
            public long vendor_id
            {
                get
                {
                    return Convert.ToInt64(this["vendor_id"]);
                }
                set
                {
                   
                    this["vendor_id"] = value;
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
            
            
            public long bill_number
            {
                get
                {
                    return Convert.ToInt64(this["bill_number"]);
                }
                set
                {
                   
                    this["bill_number"] = value;
                }
            }
            
            
            public DateTime bill_date
            {
                get
                {
                    return Convert.ToDateTime(this["bill_date"]);
                }
                set
                {
                   
                    this["bill_date"] = value;
                }
            }
            
            
            public DateTime due_date
            {
                get
                {
                    return Convert.ToDateTime(this["due_date"]);
                }
                set
                {
                   
                    this["due_date"] = value;
                }
            }
            
            
            public object total_amount
            {
                get
                {
                    return Convert.ToDouble(this["total_amount"]);
                }
                set
                {
                   
                    this["total_amount"] = value;
                }
            }
            
            
            public string status
            {
                get
                {
                    return Convert.ToString(this["status"]);
                }
                set
                {
                   
                    this["status"] = value;
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

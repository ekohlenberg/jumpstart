
using System;
using System.Reflection;

namespace legr3
{
    public partial class BillItem : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            tableName = "app.bill_item";
            tableBaseName = "bill_item";
            auditTableName = "audit.app_bill_item";

        }


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
            
            public long bill_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("bill_id"));
                }
                set
                {
                    setPropValue("bill_id", value);
                }
            }
            
            public string description
            {
                get
                {
                    return Convert.ToString(getPropValue("description"));
                }
                set
                {
                    setPropValue("description", value);
                }
            }
            
            public int quantity
            {
                get
                {
                    return Convert.ToInt32(getPropValue("quantity"));
                }
                set
                {
                    setPropValue("quantity", value);
                }
            }
            
            public object unit_price
            {
                get
                {
                    return Convert.ToDouble(getPropValue("unit_price"));
                }
                set
                {
                    setPropValue("unit_price", value);
                }
            }
            
            public object total_amount
            {
                get
                {
                    return Convert.ToDouble(getPropValue("total_amount"));
                }
                set
                {
                    setPropValue("total_amount", value);
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


using System;
using System.Reflection;

namespace legr3
{
    public partial class Budget : BaseObject
    {
        protected void initialize()
        {
            // Default initializer
            tableName = "app.budget";
            tableBaseName = "budget";
            auditTableName = "audit.app_budget";

rwk.Add("org_id");rwk.Add("category_id");        }


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
            
            public long category_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("category_id"));
                }
                set
                {
                    setPropValue("category_id", value);
                }
            }
            
            public object amount
            {
                get
                {
                    return Convert.ToDouble(getPropValue("amount"));
                }
                set
                {
                    setPropValue("amount", value);
                }
            }
            
            public DateTime start_date
            {
                get
                {
                    return Convert.ToDateTime(getPropValue("start_date"));
                }
                set
                {
                    setPropValue("start_date", value);
                }
            }
            
            public DateTime end_date
            {
                get
                {
                    return Convert.ToDateTime(getPropValue("end_date"));
                }
                set
                {
                    setPropValue("end_date", value);
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

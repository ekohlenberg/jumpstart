
using System;
using System.Reflection;

namespace legr3
{
    public partial class Account : BaseObject
    {
        protected void initialize()
        {
            // Default initializer
            tableName = "app.account";
            tableBaseName = "account";
            auditTableName = "audit.app_account";

rwk.Add("org_id");rwk.Add("account_name");        }


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
            
            public string account_name
            {
                get
                {
                    return Convert.ToString(getPropValue("account_name"));
                }
                set
                {
                    setPropValue("account_name", value);
                }
            }
            
            public string account_type
            {
                get
                {
                    return Convert.ToString(getPropValue("account_type"));
                }
                set
                {
                    setPropValue("account_type", value);
                }
            }
            
            public object balance
            {
                get
                {
                    return Convert.ToDouble(getPropValue("balance"));
                }
                set
                {
                    setPropValue("balance", value);
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


using System;
using System.Reflection;

namespace defarge
{
    public partial class User : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "User";
            tableName = "app.user";
            tableBaseName = "user";
            auditTableName = "audit.app_user";


            rwk.Add("email");
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
            
            public string username
            {
                get
                {
                    return Convert.ToString(getPropValue("username"));
                }
                set
                {
                    setPropValue("username", value);
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
            
            public DateTime last_login_date
            {
                get
                {
                    return Convert.ToDateTime(getPropValue("last_login_date"));
                }
                set
                {
                    setPropValue("last_login_date", value);
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

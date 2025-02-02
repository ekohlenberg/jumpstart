
using System;
using System.Reflection;

namespace defarge
{
    public partial class UserPassword : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "UserPassword";
            tableName = "sec.user_password";
            tableBaseName = "user_password";
            auditTableName = "audit.sec_user_password";


            rwk.Add("user_id");
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
            
            public long user_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("user_id"));
                }
                set
                {
                    setPropValue("user_id", value);
                }
            }
            
            public string password_hash
            {
                get
                {
                    return Convert.ToString(getPropValue("password_hash"));
                }
                set
                {
                    setPropValue("password_hash", value);
                }
            }
            
            public DateTime expiry
            {
                get
                {
                    return Convert.ToDateTime(getPropValue("expiry"));
                }
                set
                {
                    setPropValue("expiry", value);
                }
            }
            
            public int needs_reset
            {
                get
                {
                    return Convert.ToInt32(getPropValue("needs_reset"));
                }
                set
                {
                    setPropValue("needs_reset", value);
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

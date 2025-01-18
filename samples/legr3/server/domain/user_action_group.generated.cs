
using System;
using System.Reflection;

namespace 
{
    public partial class UserActionGroup : BaseObject
    {
        protected void initialize()
        {
            // Default initializer
            tableName = "sec.user_action_group";
            tableBaseName = "user_action_group";
            auditTableName = "audit.sec_user_action_group";

rwk.Add("user_id");rwk.Add("action_group_id");        }


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
            
            public long action_group_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("action_group_id"));
                }
                set
                {
                    setPropValue("action_group_id", value);
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

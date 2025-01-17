
using System;
using System.Reflection;

namespace legr3
{
    public partial class ActionGroupMap : BaseObject
    {
        protected void initialize()
        {
            // Default initializer
            tableName = "sec.action_group_map";
            tableBaseName = "action_group_map";
            auditTableName = "audit.sec_action_group_map";

rwk.Add("action_id");rwk.Add("action_group_id");        }


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
            
            public long action_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("action_id"));
                }
                set
                {
                    setPropValue("action_id", value);
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

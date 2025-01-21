
using System;
using System.Reflection;

namespace legr3
{
    public partial class OpRoleMember : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            tableName = "sec.op_role_member";
            tableBaseName = "op_role_member";
            auditTableName = "audit.sec_op_role_member";

rwk.Add("user_id");rwk.Add("op_role_id");        }


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
            
            public long op_role_id
            {
                get
                {
                    return Convert.ToInt64(getPropValue("op_role_id"));
                }
                set
                {
                    setPropValue("op_role_id", value);
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


using System;
using System.Reflection;

namespace legr3
{
    public partial class OpRoleMember : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "OpRoleMember";
            tableName = "sec.op_role_member";
            tableBaseName = "op_role_member";
            auditTableName = "audit.sec_op_role_member";


            rwk.Add("user_id");
            
            rwk.Add("op_role_id");
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
            
            
            public long user_id
            {
                get
                {
                    return Convert.ToInt64(this["user_id"]);
                }
                set
                {
                   
                    this["user_id"] = value;
                }
            }
            
            
            public long op_role_id
            {
                get
                {
                    return Convert.ToInt64(this["op_role_id"]);
                }
                set
                {
                   
                    this["op_role_id"] = value;
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

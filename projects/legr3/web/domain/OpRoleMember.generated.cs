
using System;
using System.Reflection;

namespace legr3
{
    [Label("Operation Role Members")]
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


            [Label("Member ID")]
            public long id
            {
                get
                {
                    return Convert.ToInt64(this["id"].ToString());
                }
                set
                {
                   
                    this["id"] = value;
                }
            }
            
            [Label("Username")]
            public long user_id
            {
                get
                {
                    return Convert.ToInt64(this["user_id"].ToString());
                }
                set
                {
                   
                    this["user_id"] = value;
                }
            }
            
            [Label("Role")]
            public long op_role_id
            {
                get
                {
                    return Convert.ToInt64(this["op_role_id"].ToString());
                }
                set
                {
                   
                    this["op_role_id"] = value;
                }
            }
            
            [Label("Active")]
            public int is_active
            {
                get
                {
                    return Convert.ToInt32(this["is_active"].ToString());
                }
                set
                {
                   
                    this["is_active"] = value;
                }
            }
            
            [Label("Created By")]
            public string created_by
            {
                get
                {
                    return Convert.ToString(this["created_by"].ToString());
                }
                set
                {
                   
                    this["created_by"] = value;
                }
            }
            
            [Label("Last Updated")]
            public DateTime last_updated
            {
                get
                {
                    return Convert.ToDateTime(this["last_updated"].ToString());
                }
                set
                {
                   
                    this["last_updated"] = value;
                }
            }
            
            [Label("Last Updated By")]
            public string last_updated_by
            {
                get
                {
                    return Convert.ToString(this["last_updated_by"].ToString());
                }
                set
                {
                   
                    this["last_updated_by"] = value;
                }
            }
            
            [Label("Version")]
            public int version
            {
                get
                {
                    return Convert.ToInt32(this["version"].ToString());
                }
                set
                {
                   
                    this["version"] = value;
                }
            }
                }
}

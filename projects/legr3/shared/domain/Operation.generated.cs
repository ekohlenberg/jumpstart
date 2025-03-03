
using System;
using System.Reflection;

namespace legr3
{
    [Label("Operations")]
    public partial class Operation : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Operation";
            tableName = "sec.operation";
            tableBaseName = "operation";
            auditTableName = "audit.sec_operation";

        }


            [Label("Action ID")]
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
            
            [Label("Object")]
            public string objectname
            {
                get
                {
                    return Convert.ToString(this["objectname"]);
                }
                set
                {
                   
                    this["objectname"] = value;
                }
            }
            
            [Label("Method")]
            public string methodname
            {
                get
                {
                    return Convert.ToString(this["methodname"]);
                }
                set
                {
                   
                    this["methodname"] = value;
                }
            }
            
            [Label("Active")]
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
            
            [Label("Created By")]
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
            
            [Label("Last Updated")]
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
            
            [Label("Last Updated By")]
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
            
            [Label("Version")]
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

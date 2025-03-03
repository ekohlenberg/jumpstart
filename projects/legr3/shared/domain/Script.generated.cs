
using System;
using System.Reflection;

namespace legr3
{
    [Label("Scripts")]
    public partial class Script : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Script";
            tableName = "core.script";
            tableBaseName = "script";
            auditTableName = "audit.core_script";


            rwk.Add("name");
                    }


            [Label("Script ID")]
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
            
            [Label("Name")]
            public string name
            {
                get
                {
                    return Convert.ToString(this["name"]);
                }
                set
                {
                   
                    this["name"] = value;
                }
            }
            
            [Label("Source Code")]
            public string source
            {
                get
                {
                    return Convert.ToString(this["source"]);
                }
                set
                {
                   
                    this["source"] = value;
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

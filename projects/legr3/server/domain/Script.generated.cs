
using System;
using System.Reflection;

namespace legr3
{
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


using System;
using System.Reflection;

namespace defarge
{
    [Label("Server")]
    public partial class Server : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Server";
            tableName = "core.server";
            tableBaseName = "server";
            auditTableName = "audit.core_server";


            rwk.Add("name");
            
            rwk.Add("type");
            
            rwk.Add("address");
            
            rwk.Add("port");
                    }


            [Label("Server ID")]
            public long id
            {
                get
                {
                    long _id;

                             _id = default(long);
                                                 
                    if(this.ContainsKey("id"))
                    {
                       _id = Convert.ToInt64(this["id"].ToString());
                    }
                    return _id;
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
                    string _name;

                            _name = string.Empty;
                                                
                    if(this.ContainsKey("name"))
                    {
                       _name = Convert.ToString(this["name"].ToString());
                    }
                    return _name;
                }
                set
                {
                   
                    this["name"] = value;
                }
            }
            
            [Label("Type")]
            public string type
            {
                get
                {
                    string _type;

                            _type = string.Empty;
                                                
                    if(this.ContainsKey("type"))
                    {
                       _type = Convert.ToString(this["type"].ToString());
                    }
                    return _type;
                }
                set
                {
                   
                    this["type"] = value;
                }
            }
            
            [Label("Address")]
            public string address
            {
                get
                {
                    string _address;

                            _address = string.Empty;
                                                
                    if(this.ContainsKey("address"))
                    {
                       _address = Convert.ToString(this["address"].ToString());
                    }
                    return _address;
                }
                set
                {
                   
                    this["address"] = value;
                }
            }
            
            [Label("Port")]
            public int port
            {
                get
                {
                    int _port;

                             _port = default(int);
                                                 
                    if(this.ContainsKey("port"))
                    {
                       _port = Convert.ToInt32(this["port"].ToString());
                    }
                    return _port;
                }
                set
                {
                   
                    this["port"] = value;
                }
            }
            
            [Label("Is Default")]
            public int is_default
            {
                get
                {
                    int _is_default;

                             _is_default = default(int);
                                                 
                    if(this.ContainsKey("is_default"))
                    {
                       _is_default = Convert.ToInt32(this["is_default"].ToString());
                    }
                    return _is_default;
                }
                set
                {
                   
                    this["is_default"] = value;
                }
            }
            
            [Label("Active")]
            public int is_active
            {
                get
                {
                    int _is_active;

                             _is_active = default(int);
                                                 
                    if(this.ContainsKey("is_active"))
                    {
                       _is_active = Convert.ToInt32(this["is_active"].ToString());
                    }
                    return _is_active;
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
                    string _created_by;

                            _created_by = string.Empty;
                                                
                    if(this.ContainsKey("created_by"))
                    {
                       _created_by = Convert.ToString(this["created_by"].ToString());
                    }
                    return _created_by;
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
                    DateTime _last_updated;

                             _last_updated = default(DateTime);
                                                 
                    if(this.ContainsKey("last_updated"))
                    {
                       _last_updated = Convert.ToDateTime(this["last_updated"].ToString());
                    }
                    return _last_updated;
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
                    string _last_updated_by;

                            _last_updated_by = string.Empty;
                                                
                    if(this.ContainsKey("last_updated_by"))
                    {
                       _last_updated_by = Convert.ToString(this["last_updated_by"].ToString());
                    }
                    return _last_updated_by;
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
                    int _version;

                             _version = default(int);
                                                 
                    if(this.ContainsKey("version"))
                    {
                       _version = Convert.ToInt32(this["version"].ToString());
                    }
                    return _version;
                }
                set
                {
                   
                    this["version"] = value;
                }
            }
                }
}

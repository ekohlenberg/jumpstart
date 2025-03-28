
using System;
using System.Reflection;

namespace legr3
{
    [Label("Account")]
    public partial class Account : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Account";
            tableName = "app.account";
            tableBaseName = "account";
            auditTableName = "audit.app_account";


            rwk.Add("org_id");
            
            rwk.Add("account_name");
                    }


            [Label("Account ID")]
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
            
            [Label("Organization")]
            public long org_id
            {
                get
                {
                    long _org_id;

                             _org_id = default(long);
                                                 
                    if(this.ContainsKey("org_id"))
                    {
                       _org_id = Convert.ToInt64(this["org_id"].ToString());
                    }
                    return _org_id;
                }
                set
                {
                   
                    this["org_id"] = value;
                }
            }
            
            [Label("Name")]
            public string account_name
            {
                get
                {
                    string _account_name;

                            _account_name = string.Empty;
                                                
                    if(this.ContainsKey("account_name"))
                    {
                       _account_name = Convert.ToString(this["account_name"].ToString());
                    }
                    return _account_name;
                }
                set
                {
                   
                    this["account_name"] = value;
                }
            }
            
            [Label("Type")]
            public string account_type
            {
                get
                {
                    string _account_type;

                            _account_type = string.Empty;
                                                
                    if(this.ContainsKey("account_type"))
                    {
                       _account_type = Convert.ToString(this["account_type"].ToString());
                    }
                    return _account_type;
                }
                set
                {
                   
                    this["account_type"] = value;
                }
            }
            
            [Label("Balance")]
            public object balance
            {
                get
                {
                    object _balance;

                             _balance = default(object);
                                                 
                    if(this.ContainsKey("balance"))
                    {
                       _balance = Convert.ToDouble(this["balance"].ToString());
                    }
                    return _balance;
                }
                set
                {
                   
                    this["balance"] = value;
                }
            }
            
            [Label("Created")]
            public DateTime created_date
            {
                get
                {
                    DateTime _created_date;

                             _created_date = default(DateTime);
                                                 
                    if(this.ContainsKey("created_date"))
                    {
                       _created_date = Convert.ToDateTime(this["created_date"].ToString());
                    }
                    return _created_date;
                }
                set
                {
                   
                    this["created_date"] = value;
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

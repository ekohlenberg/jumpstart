
using System;
using System.Reflection;

namespace legr3
{
    [Label("Transaction")]
    public partial class Transaction : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Transaction";
            tableName = "app.transaction";
            tableBaseName = "transaction";
            auditTableName = "audit.app_transaction";

        }


            [Label("Transaction ID")]
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
            
            [Label("Account ID")]
            public long account_id
            {
                get
                {
                    long _account_id;

                             _account_id = default(long);
                                                 
                    if(this.ContainsKey("account_id"))
                    {
                       _account_id = Convert.ToInt64(this["account_id"].ToString());
                    }
                    return _account_id;
                }
                set
                {
                   
                    this["account_id"] = value;
                }
            }
            
            [Label("Organization ID")]
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
            
            [Label("Transaction Date")]
            public DateTime transaction_date
            {
                get
                {
                    DateTime _transaction_date;

                             _transaction_date = default(DateTime);
                                                 
                    if(this.ContainsKey("transaction_date"))
                    {
                       _transaction_date = Convert.ToDateTime(this["transaction_date"].ToString());
                    }
                    return _transaction_date;
                }
                set
                {
                   
                    this["transaction_date"] = value;
                }
            }
            
            [Label("Amount")]
            public object amount
            {
                get
                {
                    object _amount;

                             _amount = default(object);
                                                 
                    if(this.ContainsKey("amount"))
                    {
                       _amount = Convert.ToDouble(this["amount"].ToString());
                    }
                    return _amount;
                }
                set
                {
                   
                    this["amount"] = value;
                }
            }
            
            [Label("Transaction Type")]
            public string transaction_type
            {
                get
                {
                    string _transaction_type;

                            _transaction_type = string.Empty;
                                                
                    if(this.ContainsKey("transaction_type"))
                    {
                       _transaction_type = Convert.ToString(this["transaction_type"].ToString());
                    }
                    return _transaction_type;
                }
                set
                {
                   
                    this["transaction_type"] = value;
                }
            }
            
            [Label("Description")]
            public string description
            {
                get
                {
                    string _description;

                            _description = string.Empty;
                                                
                    if(this.ContainsKey("description"))
                    {
                       _description = Convert.ToString(this["description"].ToString());
                    }
                    return _description;
                }
                set
                {
                   
                    this["description"] = value;
                }
            }
            
            [Label("Created Date")]
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

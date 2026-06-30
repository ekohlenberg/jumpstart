

using System;
using System.Reflection;
using System.Collections.Generic;

namespace jumptest
{
    [ClassInfo("Password")]
    public partial class PrincipalPassword : BaseObject
    {
        public PrincipalPassword(BaseObject baseObject) : base(baseObject)
        {
            Initialize();
        }

        protected override void Initialize()
        {
            // Default initializer
            domainName = "PrincipalPassword";
            tableName = "core.principal_password";
            schemaName = "core";
            tableBaseName = "principal_password";
            auditTableName = "core.principal_password"; // history rows live in the same table (is_active=0)
            isAudited = true;


            rwk.Add("principal_id");
            

            _defaults["id"] = default(long);
            
            _defaults["principal_id"] = default(long);
            
            _defaults["password_hash"] = default(string);
            
            _defaults["expiry"] = default(DateTime);
            
            _defaults["needs_reset"] = default(int);
            
            _defaults["is_active"] = default(int);
            
            _defaults["created_by"] = default(string);
            
            _defaults["last_updated"] = default(DateTime);
            
            _defaults["last_updated_by"] = default(string);
            
            _defaults["txn_id"] = default(long);
                    }


            [ColumnInfo("Principal ID", "", "", "", "")]
            public long id
            {
                get
                {
                    long _id;

                             _id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("id"))
                        {
                        _id = Convert.ToInt64(this["id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting id: {e.Message}");
                        _id = default(long);
                    }
                    return _id;
                }
                set
                {
                   
                    this["id"] = value;
                }
            }
            
            [ColumnInfo("Principal ID", "Principal", "map", "principal", "principal")]
            public long principal_id
            {
                get
                {
                    long _principal_id;

                             _principal_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("principal_id"))
                        {
                        _principal_id = Convert.ToInt64(this["principal_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting principal_id: {e.Message}");
                        _principal_id = default(long);
                    }
                    return _principal_id;
                }
                set
                {
                   
                    this["principal_id"] = value;
                }
            }
            
            [ColumnInfo("Password", "", "", "", "")]
            public string password_hash
            {
                get
                {
                    string _password_hash;

                            _password_hash = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("password_hash"))
                        {
                        _password_hash = Convert.ToString(this["password_hash"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting password_hash: {e.Message}");
                        _password_hash = default(string);
                    }
                    return _password_hash;
                }
                set
                {
                   
                    this["password_hash"] = value;
                }
            }
            
            [ColumnInfo("Expiry", "", "", "", "")]
            public DateTime expiry
            {
                get
                {
                    DateTime _expiry;

                             _expiry = default(DateTime);
                                                 
                    try
                    {
                        if(this.ContainsKey("expiry"))
                        {
                        _expiry = Convert.ToDateTime(this["expiry"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting expiry: {e.Message}");
                        _expiry = default(DateTime);
                    }
                    return _expiry;
                }
                set
                {
                   
                    this["expiry"] = value;
                }
            }
            
            [ColumnInfo("Needs Reset", "", "", "", "")]
            public int needs_reset
            {
                get
                {
                    int _needs_reset;

                             _needs_reset = default(int);
                                                 
                    try
                    {
                        if(this.ContainsKey("needs_reset"))
                        {
                        _needs_reset = Convert.ToInt32(this["needs_reset"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting needs_reset: {e.Message}");
                        _needs_reset = default(int);
                    }
                    return _needs_reset;
                }
                set
                {
                   
                    this["needs_reset"] = value;
                }
            }
            
            [ColumnInfo("Active", "", "", "", "")]
            public int is_active
            {
                get
                {
                    int _is_active;

                             _is_active = default(int);
                                                 
                    try
                    {
                        if(this.ContainsKey("is_active"))
                        {
                        _is_active = Convert.ToInt32(this["is_active"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting is_active: {e.Message}");
                        _is_active = default(int);
                    }
                    return _is_active;
                }
                set
                {
                   
                    this["is_active"] = value;
                }
            }
            
            [ColumnInfo("Created By", "", "", "", "")]
            public string created_by
            {
                get
                {
                    string _created_by;

                            _created_by = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("created_by"))
                        {
                        _created_by = Convert.ToString(this["created_by"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting created_by: {e.Message}");
                        _created_by = default(string);
                    }
                    return _created_by;
                }
                set
                {
                   
                    this["created_by"] = value;
                }
            }
            
            [ColumnInfo("Last Updated", "", "", "", "")]
            public DateTime last_updated
            {
                get
                {
                    DateTime _last_updated;

                             _last_updated = default(DateTime);
                                                 
                    try
                    {
                        if(this.ContainsKey("last_updated"))
                        {
                        _last_updated = Convert.ToDateTime(this["last_updated"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting last_updated: {e.Message}");
                        _last_updated = default(DateTime);
                    }
                    return _last_updated;
                }
                set
                {
                   
                    this["last_updated"] = value;
                }
            }
            
            [ColumnInfo("Last Updated By", "", "", "", "")]
            public string last_updated_by
            {
                get
                {
                    string _last_updated_by;

                            _last_updated_by = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("last_updated_by"))
                        {
                        _last_updated_by = Convert.ToString(this["last_updated_by"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting last_updated_by: {e.Message}");
                        _last_updated_by = default(string);
                    }
                    return _last_updated_by;
                }
                set
                {
                   
                    this["last_updated_by"] = value;
                }
            }
            
            [ColumnInfo("Txn Id", "", "", "", "")]
            public long txn_id
            {
                get
                {
                    long _txn_id;

                             _txn_id = default(long);
                                                 
                    try
                    {
                        if(this.ContainsKey("txn_id"))
                        {
                        _txn_id = Convert.ToInt64(this["txn_id"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting txn_id: {e.Message}");
                        _txn_id = default(long);
                    }
                    return _txn_id;
                }
                set
                {
                   
                    this["txn_id"] = value;
                }
            }
                }

    public partial class PrincipalPasswordHistory : PrincipalPassword
    {
        protected override void Initialize()
        {
            // History rows live in the same table as the active row.
            // is_active=0 rows are prior versions; is_active=1 is the current row.
            base.Initialize();
            domainName = "PrincipalPasswordHistory";
            // tableName and schemaName remain the same as the parent class
        }
    }


    // View class that extends the base domain object with RWK columns from foreign key joins
    public class PrincipalPasswordView : PrincipalPassword
    {

            [ColumnInfo("Principal ID Email", "", "", "", "")]
            public string principal_email
            {
                get
                {
                    string _principal_email;

                            _principal_email = string.Empty;
                                                
                    try
                    {
                        if(this.ContainsKey("principal_email"))
                        {
                        _principal_email = Convert.ToString(this["principal_email"].ToString());
                        }
                    }
                    catch(Exception )
                    {
                        //Logger.Error($"Error getting principal_email: {e.Message}");
                        _principal_email = default(string);
                    }
                    return _principal_email;
                }
                set
                {
                   
                    this["principal_email"] = value;
                }
            }
                }
        }


using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

    public  class Org : BaseObject
    {
        protected void Initialize()
        {
            // Default initializer
            domainName = "Org";
            tableName = "app.org";
            tableBaseName = "org";
            auditTableName = "audit.app_org";

            rwk.Add("name");        
            }


            public long id
            {
                get
                {
                    object v = getPropValue("id").ToString();
                    Console.WriteLine("id = >" + v + "<");
                    try {
                    return Convert.ToInt64(v);
                    }
                    catch (Exception x)
                    {
                        throw new Exception("error converting >" + v + "<, type " + v.GetType().Name, x);
                    }
                }
                set
                {
                    setPropValue("id", value);
                }
            }
            
            public string name
           {
                get
                {
                    return Convert.ToString(getPropValue("name"));
                }
                set
                {
                    setPropValue("name", value);
                }
            }
           
            public int is_active
            {
                get
                {
                    object o = null;
                    int v = default(int);
                    try 
                    {
                        o = null;
                        if (ContainsKey("is_active"))
                        {
                            o = getPropValue("is_active");
                            
                            try {
                                v = Convert.ToInt32(o);
                            }
                            catch(Exception y)
                            {
                                if (!Int32.TryParse(o.ToString(), out v))
                                    throw new Exception("Cannot parse " + o, y);

                            }
                        }
                    
                        return v;
                    }
                    catch(Exception x)
                    {
                        string type = string.Empty;

                        if (o == null) {
                            o = "null";
                            type = "null";
                        }
                        else
                        {
                            type  = o.GetType().Name;
                        }

                        throw new Exception("Error converting >" + o + "<, type " + type, x);
                    }
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
                    return Convert.ToDateTime(getPropValue("last_updated").ToString());
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
                    return Convert.ToInt32(getPropValue("version").ToString());
                }
                set
                {
                    setPropValue("version", value);
                }
            }
    }

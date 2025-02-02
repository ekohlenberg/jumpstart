using System;
using System.Collections.Generic;
using System.Text;

namespace defarge
{
    public class BaseObject : Dictionary<string, object>
    {
        public BaseObject() { }

        public BaseObject( BaseObject t)
        {
            foreach( string k in t.Keys)
            {
                setPropValue(k, t[k]);
            }
        }

        public string domainName {get;  set;}
        public string tableName { get;  set; }
        public string tableBaseName{ get;  set; }
        public string auditTableName { get;  set;}
        protected List<string> rwk = new List<string>();

        public List<string> getRwk() { return rwk;  }

        
        public object getPropValue(string propName)
        {
            object result = DBNull.Value;
            //propName = propName.Replace("get_", "").Replace("set_", "");
            if (this.ContainsKey(propName))
            {
                result = this[propName];
            }
            return result;
        }

        public void setPropValue(string propName, object value)
        {
            //propName = propName.Replace("get_", "").Replace("set_", "");
            if (this.ContainsKey(propName))
            {
                this[propName] = value;
            }
            else
            {
                this.Add(propName, value);
            }



        }
        public override string ToString()
        {
            string s = string.Empty;

            foreach(string k in this.Keys)
            {
                s += k + " = " + this[k].ToString() + "\n";
            }

            return this.GetType().Name + "{\n" + s + "\n}";
        }
    }
}
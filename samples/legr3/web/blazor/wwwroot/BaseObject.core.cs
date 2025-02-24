using System;
using System.Collections.Generic;
using System.Text;

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

        public string? domainName {get;  set;}
        public string? tableName { get;  set; }
        public string? tableBaseName{ get;  set; }
        public string? auditTableName { get;  set;}
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

         protected T? SafeGet<T>(string key)
    {
        if (!TryGetValue(key, out var rawValue) || rawValue == null)
        {
            // Key is missing or null, so return default
            return default;
        }

        // If it's already the correct type, just return it
        if (rawValue is T correctlyTyped)
        {
            return correctlyTyped;
        }

        // Attempt to convert it to the target type
        try
        {
            // First, try to convert to string
            string? strValue = rawValue.ToString();

            strValue ??= string.Empty;
            // Then, attempt to convert the string to our target type
            // Convert.ChangeType can handle many standard conversions.
            // If it fails, we catch below and return default.
            T convertedValue = (T)Convert.ChangeType(strValue, typeof(T));
            return convertedValue;
        }
        catch
        {
            // If anything goes wrong, return default
            return default;
        }
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

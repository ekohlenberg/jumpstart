using System;
     using System.Reflection;
     
     namespace legr
     {
         public partial class  : Tuple
         {
             protected void initialize()
             {
                 // Default initializer
                tableName = "sec.org";

                tableBaseName = "org";

                auditTableName = "audit.org";

                rwk.Add(name);

             }

             
 public System.Int64 id
{ 
get
{
    return Convert.ToInt64(getPropValue(id));
}
set
{
    setPropValue(id, value);
}
}
 public System.String name
{ 
get
{
    return Convert.ToString(getPropValue(name));
}
set
{
    setPropValue(name, value);
}
}

        }
    }
}

using System;
     using System.Reflection;
     
     namespace legr
     {
         public partial class  : Tuple
         {
             protected void initialize()
             {
                 // Default initializer
                tableName = "app.category";

                tableBaseName = "category";

                auditTableName = "audit.category";

                rwk.Add(org_id);
 rwk.Add(category_name);

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
 public System.Int64 org_id
{ 
get
{
    return Convert.ToInt64(getPropValue(org_id));
}
set
{
    setPropValue(org_id, value);
}
}
 public System.String category_name
{ 
get
{
    return Convert.ToString(getPropValue(category_name));
}
set
{
    setPropValue(category_name, value);
}
}
 public System.String category_type
{ 
get
{
    return Convert.ToString(getPropValue(category_type));
}
set
{
    setPropValue(category_type, value);
}
}

        }
    }
}

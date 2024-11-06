using System;
     using System.Reflection;
     
     namespace legr
     {
         public partial class  : Tuple
         {
             protected void initialize()
             {
                 // Default initializer
                tableName = "app.budget";

                tableBaseName = "budget";

                auditTableName = "audit.budget";

                rwk.Add(org_id);
 rwk.Add(category_id);

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
 public System.Int64 category_id
{ 
get
{
    return Convert.ToInt64(getPropValue(category_id));
}
set
{
    setPropValue(category_id, value);
}
}
 public System.Double amount
{ 
get
{
    return Convert.ToDouble(getPropValue(amount));
}
set
{
    setPropValue(amount, value);
}
}
 public System.DateTime start_date
{ 
get
{
    return Convert.ToDateTime(getPropValue(start_date));
}
set
{
    setPropValue(start_date, value);
}
}
 public System.DateTime end_date
{ 
get
{
    return Convert.ToDateTime(getPropValue(end_date));
}
set
{
    setPropValue(end_date, value);
}
}

        }
    }
}

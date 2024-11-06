using System;
     using System.Reflection;
     
     namespace legr
     {
         public partial class  : Tuple
         {
             protected void initialize()
             {
                 // Default initializer
                tableName = "app.account";

                tableBaseName = "account";

                auditTableName = "audit.account";

                rwk.Add(org_id);
 rwk.Add(account_name);

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
 public System.String account_name
{ 
get
{
    return Convert.ToString(getPropValue(account_name));
}
set
{
    setPropValue(account_name, value);
}
}
 public System.String account_type
{ 
get
{
    return Convert.ToString(getPropValue(account_type));
}
set
{
    setPropValue(account_type, value);
}
}
 public System.Double balance
{ 
get
{
    return Convert.ToDouble(getPropValue(balance));
}
set
{
    setPropValue(balance, value);
}
}
 public System.DateTime created_date
{ 
get
{
    return Convert.ToDateTime(getPropValue(created_date));
}
set
{
    setPropValue(created_date, value);
}
}

        }
    }
}

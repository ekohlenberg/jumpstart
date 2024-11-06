using System;
     using System.Reflection;
     
     namespace legr
     {
         public partial class  : Tuple
         {
             protected void initialize()
             {
                 // Default initializer
                tableName = "sec.user";

                tableBaseName = "user";

                auditTableName = "audit.user";

                rwk.Add(email);

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
 public System.String username
{ 
get
{
    return Convert.ToString(getPropValue(username));
}
set
{
    setPropValue(username, value);
}
}
 public System.String password_hash
{ 
get
{
    return Convert.ToString(getPropValue(password_hash));
}
set
{
    setPropValue(password_hash, value);
}
}
 public System.String first_name
{ 
get
{
    return Convert.ToString(getPropValue(first_name));
}
set
{
    setPropValue(first_name, value);
}
}
 public System.String last_name
{ 
get
{
    return Convert.ToString(getPropValue(last_name));
}
set
{
    setPropValue(last_name, value);
}
}
 public System.String email
{ 
get
{
    return Convert.ToString(getPropValue(email));
}
set
{
    setPropValue(email, value);
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
 public System.DateTime last_login_date
{ 
get
{
    return Convert.ToDateTime(getPropValue(last_login_date));
}
set
{
    setPropValue(last_login_date, value);
}
}

        }
    }
}

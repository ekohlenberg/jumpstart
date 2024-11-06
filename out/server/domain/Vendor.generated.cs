using System;
     using System.Reflection;
     
     namespace legr
     {
         public partial class  : Tuple
         {
             protected void initialize()
             {
                 // Default initializer
                tableName = "app.vendor";

                tableBaseName = "vendor";

                auditTableName = "audit.vendor";

                rwk.Add(org_id);
 rwk.Add(vendor_name);

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
 public System.String vendor_name
{ 
get
{
    return Convert.ToString(getPropValue(vendor_name));
}
set
{
    setPropValue(vendor_name, value);
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
 public System.String phone
{ 
get
{
    return Convert.ToString(getPropValue(phone));
}
set
{
    setPropValue(phone, value);
}
}
 public System.String billing_address
{ 
get
{
    return Convert.ToString(getPropValue(billing_address));
}
set
{
    setPropValue(billing_address, value);
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

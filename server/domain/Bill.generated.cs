using System;
     using System.Reflection;
     
     namespace legr
     {
         public partial class  : Tuple
         {
             protected void initialize()
             {
                 // Default initializer
                tableName = "app.bill";

                tableBaseName = "bill";

                auditTableName = "audit.bill";

                
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
 public System.Int64 vendor_id
{ 
get
{
    return Convert.ToInt64(getPropValue(vendor_id));
}
set
{
    setPropValue(vendor_id, value);
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
 public System.Int64 bill_number
{ 
get
{
    return Convert.ToInt64(getPropValue(bill_number));
}
set
{
    setPropValue(bill_number, value);
}
}
 public System.DateTime bill_date
{ 
get
{
    return Convert.ToDateTime(getPropValue(bill_date));
}
set
{
    setPropValue(bill_date, value);
}
}
 public System.DateTime due_date
{ 
get
{
    return Convert.ToDateTime(getPropValue(due_date));
}
set
{
    setPropValue(due_date, value);
}
}
 public System.Double total_amount
{ 
get
{
    return Convert.ToDouble(getPropValue(total_amount));
}
set
{
    setPropValue(total_amount, value);
}
}
 public System.String status
{ 
get
{
    return Convert.ToString(getPropValue(status));
}
set
{
    setPropValue(status, value);
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

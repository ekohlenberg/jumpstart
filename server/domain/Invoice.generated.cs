using System;
     using System.Reflection;
     
     namespace legr
     {
         public partial class  : Tuple
         {
             protected void initialize()
             {
                 // Default initializer
                tableName = "app.invoice";

                tableBaseName = "invoice";

                auditTableName = "audit.invoice";

                
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
 public System.Int64 customer_id
{ 
get
{
    return Convert.ToInt64(getPropValue(customer_id));
}
set
{
    setPropValue(customer_id, value);
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
 public System.Int64 invoice_number
{ 
get
{
    return Convert.ToInt64(getPropValue(invoice_number));
}
set
{
    setPropValue(invoice_number, value);
}
}
 public System.DateTime invoice_date
{ 
get
{
    return Convert.ToDateTime(getPropValue(invoice_date));
}
set
{
    setPropValue(invoice_date, value);
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

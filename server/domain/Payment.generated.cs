using System;
     using System.Reflection;
     
     namespace legr
     {
         public partial class  : Tuple
         {
             protected void initialize()
             {
                 // Default initializer
                tableName = "app.payment";

                tableBaseName = "payment";

                auditTableName = "audit.payment";

                
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
 public System.Int64 invoice_id
{ 
get
{
    return Convert.ToInt64(getPropValue(invoice_id));
}
set
{
    setPropValue(invoice_id, value);
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
 public System.DateTime payment_date
{ 
get
{
    return Convert.ToDateTime(getPropValue(payment_date));
}
set
{
    setPropValue(payment_date, value);
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
 public System.String payment_method
{ 
get
{
    return Convert.ToString(getPropValue(payment_method));
}
set
{
    setPropValue(payment_method, value);
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

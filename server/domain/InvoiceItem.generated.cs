using System;
     using System.Reflection;
     
     namespace legr
     {
         public partial class  : Tuple
         {
             protected void initialize()
             {
                 // Default initializer
                tableName = "app.invoice_item";

                tableBaseName = "invoice_item";

                auditTableName = "audit.invoice_item";

                
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
 public System.String description
{ 
get
{
    return Convert.ToString(getPropValue(description));
}
set
{
    setPropValue(description, value);
}
}
 public System.Int32 quantity
{ 
get
{
    return Convert.ToInt32(getPropValue(quantity));
}
set
{
    setPropValue(quantity, value);
}
}
 public System.Double unit_price
{ 
get
{
    return Convert.ToDouble(getPropValue(unit_price));
}
set
{
    setPropValue(unit_price, value);
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

        }
    }
}

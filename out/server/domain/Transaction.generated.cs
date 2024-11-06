using System;
     using System.Reflection;
     
     namespace legr
     {
         public partial class  : Tuple
         {
             protected void initialize()
             {
                 // Default initializer
                tableName = "app.transaction";

                tableBaseName = "transaction";

                auditTableName = "audit.transaction";

                
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
 public System.Int64 account_id
{ 
get
{
    return Convert.ToInt64(getPropValue(account_id));
}
set
{
    setPropValue(account_id, value);
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
 public System.DateTime transaction_date
{ 
get
{
    return Convert.ToDateTime(getPropValue(transaction_date));
}
set
{
    setPropValue(transaction_date, value);
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
 public System.String transaction_type
{ 
get
{
    return Convert.ToString(getPropValue(transaction_type));
}
set
{
    setPropValue(transaction_type, value);
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

using System;
     using System.Reflection;
     
     namespace legr
     {
         public partial class  : Tuple
         {
             protected void initialize()
             {
                 // Default initializer
                tableName = "app.transaction_category";

                tableBaseName = "transaction_category";

                auditTableName = "audit.transaction_category";

                
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
 public System.Int64 transaction_id
{ 
get
{
    return Convert.ToInt64(getPropValue(transaction_id));
}
set
{
    setPropValue(transaction_id, value);
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

        }
    }
}

using System;
     using System.Reflection;
     
     namespace legr
     {
         public partial class  : Tuple
         {
             protected void initialize()
             {
                 // Default initializer
                tableName = "sec.user_org";

                tableBaseName = "user_org";

                auditTableName = "audit.user_org";

                rwk.Add(org_id);
 rwk.Add(user_id);

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
 public System.Int64 user_id
{ 
get
{
    return Convert.ToInt64(getPropValue(user_id));
}
set
{
    setPropValue(user_id, value);
}
}

        }
    }
}

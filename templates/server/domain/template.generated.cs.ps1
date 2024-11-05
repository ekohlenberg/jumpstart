@"
     using System;
     using System.Reflection;
     
     namespace $namespace
     {
         public partial class $className : Tuple
         {
             protected void initialize()
             {
                 // Default initializer
                tableName = "$schemaName.$tableName";`n
                tableBaseName = "$tableName";`n
                auditTableName = "audit.$tableName";`n
                $(
                    foreach($column in $columns) {
                        if ($column.rwk -eq 1) {
                        "rwk.Add(" + $($column.column_name) + ");" + $cr
                        }

                    }
                )
             }

             $( $cr   
            foreach ($column in $columns) {
                $csharpType = $typeMapping[$column.data_type]
                $convertMethod= $convertMapping[$column.data_type]
                "public " + $csharpType + $space + $($column.column_name) + $cr +
                "{ " + $cr +
                    "get" + $cr +
                    "{" + $cr +
                    "    return Convert." + $convertMethod + "(getPropValue("+ $($column.column_name) + "));" + $cr +
                    "}" + $cr +
                    "set" + $cr +
                    "{" + $cr +
                    "    setPropValue(" + $($column.column_name) + ", value);" + $cr +
                    "}" +  $cr +
                "}" + $cr                
            }
        )
        }
    }
}
"@     
        
    
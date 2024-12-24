@"

using System;
using System.Collections.Generic;


namespace $($namespace)
{
    public class BaseTest
    {
        $(
            foreach ($tableName in $metadata.Keys) {
              
                $schemaName = $metadata[$tableName][0].table_schema
                $domainObj = Convert-ToPascalCase -inputString $tableName
                $domainVar = $domainObj.ToLower()
                "protected static Stack <" + $domainObj + ">last" + $domainObj + " = new Stack<" + $domainObj+ ">();" + $cr
                "protected static Dictionary< long, " + $domainObj + "> map" + $domainObj + " = new Dictionary<long, " + $domainObj + ">();" + $cr
            }

        )
        
    }
}
"@


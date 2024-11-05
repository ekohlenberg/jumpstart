@"

using System;
using System.Collections.Generic;


namespace $($namespace)
{
    public class BaseTest
    {
        $(
            foreach ($group in $groupedMetadata) {
                $domainObj = Convert-ToPascalCase -inputString $tableName
                $domainVar = $domainObj.ToLower()
                "protected static Stack <" + $domainObj ">last" + $domainObj + " = new Stack<" + $domainObj+ ">();"
                "protected static Dictionary< long, " + $domainObj + "> map" + $domainObj + " = new Dictionary<long, " + $domainObj + ">();"
            }

        )
        
    }
}
"@


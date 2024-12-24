@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using $($namespace);


namespace $($namespace)
{
    public partial class $($domainObj)Logic : Logic
    {
    
        public static List<$($domainObj)> select()
        {
            Console.WriteLine("Processing $($domainObj)Logic select List" );

            List<$($domainObj)> $($domainVar)s = [];

            void $($domainVar)Callback(System.Data.Common.DbDataReader rdr) 
            {
                $($domainObj) $($domainVar) = [];

                DBPersist.autoAssign(rdr, $($domainVar));

                $($domainVar)s.Add($($domainVar));
            };

            DBPersist.select($($domainVar)Callback, "select * from $($schemaName).$($tableName)");

            return $($domainVar)s;
        }

        
        public static $($domainObj) get(long id)
        {
            Console.WriteLine("Processing $($domainObj)Logic get ID=" + id.ToString());

            $($domainObj) $($domainVar) = [];
            $($domainVar).id = id;

            DBPersist.get($($domainVar));

            return $($domainVar);
        }

        
        public static void insert( $($domainObj) $($domainVar))
        {
            Console.WriteLine("Processing $($domainObj)Logic insert: " + $($domainVar).ToString()  );

            $($domainVar).is_active = "Y";

            DBPersist.insert($($domainVar));
        }

       
        public static void update(long id,  $($domainObj) $($domainVar))
        {
            Console.WriteLine("Processing $($domainObj)Logic update: ID = " + id.ToString() + "\n" + $($domainVar).ToString()  );

            $($domainVar).id = id;
            DBPersist.update($($domainVar));
        }

        
        public static void delete(long id)
        {
            $($domainObj) $($domainVar) = get(id);
            $($domainVar).is_active = "N";
             DBPersist.update($($domainVar));
        }
    }
}
"@

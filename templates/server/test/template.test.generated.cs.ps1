@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using $($namespace);

namespace $($namespace)
{


    public partial class $($domainObj)Test : BaseTest
    {
        
        public static void testInsert()
        {
            $($domainObj) $($domainVar) = new $($domainObj)();

            $( for($i = 0; $i -lt $columns.count; $i++) {

                $column = $columns[$i]
                if ( ($column.column_name.EndsWith('id')))
                {
                    if ($column.fk_object.length -gt 0) {
                        [char]9 + [char]9 + [char]9 +[char]9 + [char]9 + $domainVar + '.' + $column.column_name + ' = BaseTest.getLastId( "' + $column.fk_object + '");' + [char]10
                    }
                }
                else    {

                    $testDataSet = 'random'
                    if ( $column.test_data_set.length -gt 0 ) {
                        $testDataSet =  $column.test_data_set
                    }
                    [char]9 + [char]9 + [char]9 + [char]9 + [char]9 + [char]9+ $domainVar + '.' + $column.column_name + ' = (' + $typeMapping[$column.data_type] + ') BaseTest.getTestData( ' + $domainVar + ',"' + $column.data_type + '", TestDataType.' + $testDataSet + ');' + [char]10
                }
                


            })
           Console.WriteLine("Testing $(${domainObj})Logic insert: " + $(${domainVar}).ToString()  );
  
            $($domainObj)Logic.insert($($domainVar));

            BaseTest.addLastId( "$($domainObj)", $($domainVar).id);
          
        }

    public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("$($domainObj)");
            $($domainObj) $($domainVar) = $($domainObj)Logic.get(lastId);

            $( for($i = 0; $i -lt $columns.count; $i++) {

                $column = $columns[$i]
                if ( ($column.column_name.EndsWith('id')))
                {
                    if ($column.fk_object.length -gt 0) {
                        $domainVar + '.' + $column.column_name + ' = BaseTest.getLastId( "' + $column.fk_object + '");' + [char]13
                    }
                }
                else    {

                    $testDataSet = 'random'
                    if ( $column.test_data_set.length -gt 0 ) {
                        $testDataSet =  $column.test_data_set
                    }
                    $domainVar + '.' + $column.column_name + ' = (' + $typeMapping[$column.data_type] + ') BaseTest.getTestData( ' + $domainVar + ',"' + $column.data_type + '", TestDataType.' + $testDataSet + ');' + [char]13
                }
                


            })
           Console.WriteLine("Testing $(${domainObj})Logic insert: " + $(${domainVar}).ToString()  );
  
            $($domainObj)Logic.update(lastId, $($domainVar));

            
          
        }

       
    }
}
"@

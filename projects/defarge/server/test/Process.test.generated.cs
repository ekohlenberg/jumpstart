using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ProcessTest : BaseTest
    {
        public static void testInsert()
        {
            var process = new Process();


                    process.name = Convert.ToString(BaseTest.getTestData(process, "VARCHAR", TestDataType.random));
                    
                    process.script_id = BaseTest.getLastId("script");
                    
                Console.WriteLine("Testing ProcessLogic insert: " + process.ToString());
                ProcessLogic.Create().insert(process);
                BaseTest.addLastId("process", process.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Process");
            var process = ProcessLogic.Create().get(lastId);


                        process.name = (string) BaseTest.getTestData(process, "VARCHAR", TestDataType.random);
                    
                            process.script_id = BaseTest.getLastId("script");
                        
                Console.WriteLine("Testing ProcessLogic update: " + process.ToString());
                ProcessLogic.Create().update(lastId, process);
                    }
    }
}

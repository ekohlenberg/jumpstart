using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class OperationTest : BaseTest
    {
        public static void testInsert()
        {
            var operation = new Operation();


                    operation.objectname = Convert.ToString(BaseTest.getTestData(operation, "VARCHAR", TestDataType.random));
                    
                    operation.methodname = Convert.ToString(BaseTest.getTestData(operation, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing OperationLogic insert: " + operation.ToString());
                OperationLogic.Create().insert(operation);
                BaseTest.addLastId("operation", operation.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Operation");
            var operation = OperationLogic.Create().get(lastId);


                        operation.objectname = (string) BaseTest.getTestData(operation, "VARCHAR", TestDataType.random);
                    
                        operation.methodname = (string) BaseTest.getTestData(operation, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing OperationLogic update: " + operation.ToString());
                OperationLogic.Create().update(lastId, operation);
                    }
    }
}

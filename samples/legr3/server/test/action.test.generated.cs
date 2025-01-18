using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ;

namespace 
{
    public partial class ActionTest : BaseTest
    {
        public static void testInsert()
        {
            var action = new Action();


                    action.object = Convert.ToString(BaseTest.getTestData(action, "VARCHAR", TestDataType.random));
                    
                    action.method = Convert.ToString(BaseTest.getTestData(action, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing ActionLogic insert: " + action.ToString());
                ActionLogic.Create().insert(action);
                BaseTest.addLastId("Action", action.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Action");
            var action = ActionLogic.Create().get(lastId);


                        action.object = (string) BaseTest.getTestData(action, "VARCHAR", TestDataType.random);
                    
                        action.method = (string) BaseTest.getTestData(action, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing ActionLogic update: " + action.ToString());
                ActionLogic.Create().update(lastId, action);
                    }
    }
}

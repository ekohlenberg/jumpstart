using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ;

namespace 
{
    public partial class ActionGroupTest : BaseTest
    {
        public static void testInsert()
        {
            var actiongroup = new ActionGroup();


                    actiongroup.name = Convert.ToString(BaseTest.getTestData(actiongroup, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing ActionGroupLogic insert: " + actiongroup.ToString());
                ActionGroupLogic.Create().insert(actiongroup);
                BaseTest.addLastId("ActionGroup", actiongroup.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("ActionGroup");
            var actiongroup = ActionGroupLogic.Create().get(lastId);


                        actiongroup.name = (string) BaseTest.getTestData(actiongroup, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing ActionGroupLogic update: " + actiongroup.ToString());
                ActionGroupLogic.Create().update(lastId, actiongroup);
                    }
    }
}

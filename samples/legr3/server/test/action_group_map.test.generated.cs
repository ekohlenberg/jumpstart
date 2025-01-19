using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class ActionGroupMapTest : BaseTest
    {
        public static void testInsert()
        {
            var actiongroupmap = new ActionGroupMap();


                    actiongroupmap.action_id = BaseTest.getLastId("action");
                    
                    actiongroupmap.action_group_id = BaseTest.getLastId("action_group");
                    
                Console.WriteLine("Testing ActionGroupMapLogic insert: " + actiongroupmap.ToString());
                ActionGroupMapLogic.Create().insert(actiongroupmap);
                BaseTest.addLastId("ActionGroupMap", actiongroupmap.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("ActionGroupMap");
            var actiongroupmap = ActionGroupMapLogic.Create().get(lastId);


                            actiongroupmap.action_id = BaseTest.getLastId("action");
                        
                            actiongroupmap.action_group_id = BaseTest.getLastId("action_group");
                        
                Console.WriteLine("Testing ActionGroupMapLogic update: " + actiongroupmap.ToString());
                ActionGroupMapLogic.Create().update(lastId, actiongroupmap);
                    }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class UserActionGroupTest : BaseTest
    {
        public static void testInsert()
        {
            var useractiongroup = new UserActionGroup();


                    useractiongroup.user_id = BaseTest.getLastId("user");
                    
                    useractiongroup.action_group_id = BaseTest.getLastId("action_group");
                    
                Console.WriteLine("Testing UserActionGroupLogic insert: " + useractiongroup.ToString());
                UserActionGroupLogic.Create().insert(useractiongroup);
                BaseTest.addLastId("UserActionGroup", useractiongroup.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("UserActionGroup");
            var useractiongroup = UserActionGroupLogic.Create().get(lastId);


                            useractiongroup.user_id = BaseTest.getLastId("user");
                        
                            useractiongroup.action_group_id = BaseTest.getLastId("action_group");
                        
                Console.WriteLine("Testing UserActionGroupLogic update: " + useractiongroup.ToString());
                UserActionGroupLogic.Create().update(lastId, useractiongroup);
                    }
    }
}

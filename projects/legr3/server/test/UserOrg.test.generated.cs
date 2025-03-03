using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class UserOrgTest : BaseTest
    {
        public static void testInsert()
        {
            var userorg = new UserOrg();


                    userorg.org_id = BaseTest.getLastId("org");
                    
                    userorg.user_id = BaseTest.getLastId("user");
                    
                Console.WriteLine("Testing UserOrgLogic insert: " + userorg.ToString());
                UserOrgLogic.Create().insert(userorg);
                BaseTest.addLastId("user_org", userorg.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("UserOrg");
            var userorg = UserOrgLogic.Create().get(lastId);


                            userorg.org_id = BaseTest.getLastId("org");
                        
                            userorg.user_id = BaseTest.getLastId("user");
                        
                Console.WriteLine("Testing UserOrgLogic update: " + userorg.ToString());
                UserOrgLogic.Create().update(lastId, userorg);
                    }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;

namespace legr
{


    public partial class UserOrgTest : BaseTest
    {
        
        public static void testInsert()
        {
            UserOrg userorg = new UserOrg();

            					userorg.org_id = BaseTest.getLastId( "Org");
 					userorg.user_id = BaseTest.getLastId( "User");

           Console.WriteLine("Testing UserOrgLogic insert: " + userorg.ToString()  );
  
            UserOrgLogic.insert(userorg);

            BaseTest.addLastId( "UserOrg", userorg.id);
          
        }

    public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("UserOrg");
            UserOrg userorg = UserOrgLogic.get(lastId);

            userorg.org_id = BaseTest.getLastId( "Org"); userorg.user_id = BaseTest.getLastId( "User");
           Console.WriteLine("Testing UserOrgLogic insert: " + userorg.ToString()  );
  
            UserOrgLogic.update(lastId, userorg);

            
          
        }

       
    }
}

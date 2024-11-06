using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;

namespace legr
{


    public partial class UserTest : BaseTest
    {
        
        public static void testInsert()
        {
            User user = new User();

            						user.username = (System.String) BaseTest.getTestData( user,"VARCHAR", TestDataType.usernames);
 						user.password_hash = (System.String) BaseTest.getTestData( user,"VARCHAR", TestDataType.random);
 						user.first_name = (System.String) BaseTest.getTestData( user,"VARCHAR", TestDataType.firstnames);
 						user.last_name = (System.String) BaseTest.getTestData( user,"VARCHAR", TestDataType.lastnames);
 						user.email = (System.String) BaseTest.getTestData( user,"VARCHAR", TestDataType.emailAddresses);
 						user.created_date = (System.DateTime) BaseTest.getTestData( user,"TIMESTAMP", TestDataType.random);
 						user.last_login_date = (System.DateTime) BaseTest.getTestData( user,"TIMESTAMP", TestDataType.random);

           Console.WriteLine("Testing UserLogic insert: " + user.ToString()  );
  
            UserLogic.insert(user);

            BaseTest.addLastId( "User", user.id);
          
        }

    public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("User");
            User user = UserLogic.get(lastId);

            user.username = (System.String) BaseTest.getTestData( user,"VARCHAR", TestDataType.usernames); user.password_hash = (System.String) BaseTest.getTestData( user,"VARCHAR", TestDataType.random); user.first_name = (System.String) BaseTest.getTestData( user,"VARCHAR", TestDataType.firstnames); user.last_name = (System.String) BaseTest.getTestData( user,"VARCHAR", TestDataType.lastnames); user.email = (System.String) BaseTest.getTestData( user,"VARCHAR", TestDataType.emailAddresses); user.created_date = (System.DateTime) BaseTest.getTestData( user,"TIMESTAMP", TestDataType.random); user.last_login_date = (System.DateTime) BaseTest.getTestData( user,"TIMESTAMP", TestDataType.random);
           Console.WriteLine("Testing UserLogic insert: " + user.ToString()  );
  
            UserLogic.update(lastId, user);

            
          
        }

       
    }
}

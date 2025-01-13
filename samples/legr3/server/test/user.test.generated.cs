using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class UserTest : BaseTest
    {
        public static void testInsert()
        {
            var user = new User();


                    user.password_hash = Convert.ToString(BaseTest.getTestData(user, "VARCHAR", TestDataType.random));
                    
                    user.first_name = Convert.ToString(BaseTest.getTestData(user, "VARCHAR", TestDataType.firstnames));
                    
                    user.last_name = Convert.ToString(BaseTest.getTestData(user, "VARCHAR", TestDataType.lastnames));
                    
                    user.username = Convert.ToString(BaseTest.getTestData(user, "VARCHAR", TestDataType.usernames));
                    
                    user.email = Convert.ToString(BaseTest.getTestData(user, "VARCHAR", TestDataType.emailAddresses));
                    
                    user.created_date = Convert.ToDateTime(BaseTest.getTestData(user, "TIMESTAMP", TestDataType.random));
                    
                    user.last_login_date = Convert.ToDateTime(BaseTest.getTestData(user, "TIMESTAMP", TestDataType.random));
                    
                Console.WriteLine("Testing UserLogic insert: " + user.ToString());
                UserLogic.Create().insert(user);
                BaseTest.addLastId("User", user.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("User");
            var user = UserLogic.Create().get(lastId);


                        user.password_hash = (string) BaseTest.getTestData(user, "VARCHAR", TestDataType.random);
                    
                        user.first_name = (string) BaseTest.getTestData(user, "VARCHAR", TestDataType.firstnames);
                    
                        user.last_name = (string) BaseTest.getTestData(user, "VARCHAR", TestDataType.lastnames);
                    
                        user.username = (string) BaseTest.getTestData(user, "VARCHAR", TestDataType.usernames);
                    
                        user.email = (string) BaseTest.getTestData(user, "VARCHAR", TestDataType.emailAddresses);
                    
                        user.created_date = (DateTime) BaseTest.getTestData(user, "TIMESTAMP", TestDataType.random);
                    
                        user.last_login_date = (DateTime) BaseTest.getTestData(user, "TIMESTAMP", TestDataType.random);
                    
                Console.WriteLine("Testing UserLogic update: " + user.ToString());
                UserLogic.Create().update(lastId, user);
                    }
    }
}

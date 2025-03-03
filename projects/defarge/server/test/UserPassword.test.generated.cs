using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class UserPasswordTest : BaseTest
    {
        public static void testInsert()
        {
            var userpassword = new UserPassword();


                    userpassword.user_id = BaseTest.getLastId("user");
                    
                    userpassword.password_hash = Convert.ToString(BaseTest.getTestData(userpassword, "VARCHAR", TestDataType.random));
                    
                    userpassword.expiry = Convert.ToDateTime(BaseTest.getTestData(userpassword, "TIMESTAMP", TestDataType.random));
                    
                    userpassword.needs_reset = Convert.ToInt32(BaseTest.getTestData(userpassword, "INTEGER", TestDataType.random));
                    
                Console.WriteLine("Testing UserPasswordLogic insert: " + userpassword.ToString());
                UserPasswordLogic.Create().insert(userpassword);
                BaseTest.addLastId("user_password", userpassword.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("UserPassword");
            var userpassword = UserPasswordLogic.Create().get(lastId);


                            userpassword.user_id = BaseTest.getLastId("user");
                        
                        userpassword.password_hash = (string) BaseTest.getTestData(userpassword, "VARCHAR", TestDataType.random);
                    
                        userpassword.expiry = (DateTime) BaseTest.getTestData(userpassword, "TIMESTAMP", TestDataType.random);
                    
                        userpassword.needs_reset = (int) BaseTest.getTestData(userpassword, "INTEGER", TestDataType.random);
                    
                Console.WriteLine("Testing UserPasswordLogic update: " + userpassword.ToString());
                UserPasswordLogic.Create().update(lastId, userpassword);
                    }
    }
}

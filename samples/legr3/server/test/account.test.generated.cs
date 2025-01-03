using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class AccountTest : BaseTest
    {
        public static void testInsert()
        {
            var account = new Account();


                            account.org_id = BaseTest.getLastId("Org");
                        
                        account.account_name = Convert.ToString(BaseTest.getTestData(account, "VARCHAR", TestDataType.random));
                    
                        account.account_type = Convert.ToString(BaseTest.getTestData(account, "VARCHAR", TestDataType.random));
                    
                        account.balance = Convert.ToDouble(BaseTest.getTestData(account, "NUMERIC(18,4)", TestDataType.random));
                    
                        account.created_date = Convert.ToDateTime(BaseTest.getTestData(account, "TIMESTAMP", TestDataType.random));
                    
                Console.WriteLine("Testing AccountLogic insert: " + account.ToString());
                AccountLogic.insert(account);
                BaseTest.addLastId("Account", account.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Account");
            var account = AccountLogic.get(lastId);


                            account.org_id = BaseTest.getLastId("Org");
                        
                        account.account_name = (string) BaseTest.getTestData(account, "VARCHAR", TestDataType.random);
                    
                        account.account_type = (string) BaseTest.getTestData(account, "VARCHAR", TestDataType.random);
                    
                        account.balance = (object) BaseTest.getTestData(account, "NUMERIC(18,4)", TestDataType.random);
                    
                        account.created_date = (DateTime) BaseTest.getTestData(account, "TIMESTAMP", TestDataType.random);
                    
                Console.WriteLine("Testing AccountLogic update: " + account.ToString());
                AccountLogic.update(lastId, account);
                    }
    }
}

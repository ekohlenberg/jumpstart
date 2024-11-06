using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;

namespace legr
{


    public partial class AccountTest : BaseTest
    {
        
        public static void testInsert()
        {
            Account account = new Account();

            					account.org_id = BaseTest.getLastId( "Org");
 						account.account_name = (System.String) BaseTest.getTestData( account,"VARCHAR", TestDataType.random);
 						account.account_type = (System.String) BaseTest.getTestData( account,"VARCHAR", TestDataType.random);
 						account.balance = (System.Double) BaseTest.getTestData( account,"NUMERIC(18,4)", TestDataType.random);
 						account.created_date = (System.DateTime) BaseTest.getTestData( account,"TIMESTAMP", TestDataType.random);

           Console.WriteLine("Testing AccountLogic insert: " + account.ToString()  );
  
            AccountLogic.insert(account);

            BaseTest.addLastId( "Account", account.id);
          
        }

    public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Account");
            Account account = AccountLogic.get(lastId);

            account.org_id = BaseTest.getLastId( "Org"); account.account_name = (System.String) BaseTest.getTestData( account,"VARCHAR", TestDataType.random); account.account_type = (System.String) BaseTest.getTestData( account,"VARCHAR", TestDataType.random); account.balance = (System.Double) BaseTest.getTestData( account,"NUMERIC(18,4)", TestDataType.random); account.created_date = (System.DateTime) BaseTest.getTestData( account,"TIMESTAMP", TestDataType.random);
           Console.WriteLine("Testing AccountLogic insert: " + account.ToString()  );
  
            AccountLogic.update(lastId, account);

            
          
        }

       
    }
}

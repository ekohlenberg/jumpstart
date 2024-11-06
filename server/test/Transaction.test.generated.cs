using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;

namespace legr
{


    public partial class TransactionTest : BaseTest
    {
        
        public static void testInsert()
        {
            Transaction transaction = new Transaction();

            					transaction.account_id = BaseTest.getLastId( "Account");
 					transaction.org_id = BaseTest.getLastId( "Org");
 						transaction.transaction_date = (System.DateTime) BaseTest.getTestData( transaction,"TIMESTAMP", TestDataType.random);
 						transaction.amount = (System.Double) BaseTest.getTestData( transaction,"NUMERIC(18,4)", TestDataType.random);
 						transaction.transaction_type = (System.String) BaseTest.getTestData( transaction,"VARCHAR", TestDataType.random);
 						transaction.description = (System.String) BaseTest.getTestData( transaction,"VARCHAR", TestDataType.random);
 						transaction.created_date = (System.DateTime) BaseTest.getTestData( transaction,"TIMESTAMP", TestDataType.random);

           Console.WriteLine("Testing TransactionLogic insert: " + transaction.ToString()  );
  
            TransactionLogic.insert(transaction);

            BaseTest.addLastId( "Transaction", transaction.id);
          
        }

    public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Transaction");
            Transaction transaction = TransactionLogic.get(lastId);

            transaction.account_id = BaseTest.getLastId( "Account"); transaction.org_id = BaseTest.getLastId( "Org"); transaction.transaction_date = (System.DateTime) BaseTest.getTestData( transaction,"TIMESTAMP", TestDataType.random); transaction.amount = (System.Double) BaseTest.getTestData( transaction,"NUMERIC(18,4)", TestDataType.random); transaction.transaction_type = (System.String) BaseTest.getTestData( transaction,"VARCHAR", TestDataType.random); transaction.description = (System.String) BaseTest.getTestData( transaction,"VARCHAR", TestDataType.random); transaction.created_date = (System.DateTime) BaseTest.getTestData( transaction,"TIMESTAMP", TestDataType.random);
           Console.WriteLine("Testing TransactionLogic insert: " + transaction.ToString()  );
  
            TransactionLogic.update(lastId, transaction);

            
          
        }

       
    }
}

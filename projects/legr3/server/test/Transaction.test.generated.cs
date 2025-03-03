using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class TransactionTest : BaseTest
    {
        public static void testInsert()
        {
            var transaction = new Transaction();


                    transaction.account_id = BaseTest.getLastId("account");
                    
                    transaction.org_id = BaseTest.getLastId("org");
                    
                    transaction.transaction_date = Convert.ToDateTime(BaseTest.getTestData(transaction, "TIMESTAMP", TestDataType.random));
                    
                    transaction.amount = Convert.ToDouble(BaseTest.getTestData(transaction, "NUMERIC(18,4)", TestDataType.random));
                    
                    transaction.transaction_type = Convert.ToString(BaseTest.getTestData(transaction, "VARCHAR", TestDataType.random));
                    
                    transaction.description = Convert.ToString(BaseTest.getTestData(transaction, "VARCHAR", TestDataType.random));
                    
                    transaction.created_date = Convert.ToDateTime(BaseTest.getTestData(transaction, "TIMESTAMP", TestDataType.random));
                    
                Console.WriteLine("Testing TransactionLogic insert: " + transaction.ToString());
                TransactionLogic.Create().insert(transaction);
                BaseTest.addLastId("transaction", transaction.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Transaction");
            var transaction = TransactionLogic.Create().get(lastId);


                            transaction.account_id = BaseTest.getLastId("account");
                        
                            transaction.org_id = BaseTest.getLastId("org");
                        
                        transaction.transaction_date = (DateTime) BaseTest.getTestData(transaction, "TIMESTAMP", TestDataType.random);
                    
                        transaction.amount = (object) BaseTest.getTestData(transaction, "NUMERIC(18,4)", TestDataType.random);
                    
                        transaction.transaction_type = (string) BaseTest.getTestData(transaction, "VARCHAR", TestDataType.random);
                    
                        transaction.description = (string) BaseTest.getTestData(transaction, "VARCHAR", TestDataType.random);
                    
                        transaction.created_date = (DateTime) BaseTest.getTestData(transaction, "TIMESTAMP", TestDataType.random);
                    
                Console.WriteLine("Testing TransactionLogic update: " + transaction.ToString());
                TransactionLogic.Create().update(lastId, transaction);
                    }
    }
}

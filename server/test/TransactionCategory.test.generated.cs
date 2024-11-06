using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;

namespace legr
{


    public partial class TransactionCategoryTest : BaseTest
    {
        
        public static void testInsert()
        {
            TransactionCategory transactioncategory = new TransactionCategory();

            					transactioncategory.transaction_id = BaseTest.getLastId( "Transaction");
 					transactioncategory.category_id = BaseTest.getLastId( "Category");

           Console.WriteLine("Testing TransactionCategoryLogic insert: " + transactioncategory.ToString()  );
  
            TransactionCategoryLogic.insert(transactioncategory);

            BaseTest.addLastId( "TransactionCategory", transactioncategory.id);
          
        }

    public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("TransactionCategory");
            TransactionCategory transactioncategory = TransactionCategoryLogic.get(lastId);

            transactioncategory.transaction_id = BaseTest.getLastId( "Transaction"); transactioncategory.category_id = BaseTest.getLastId( "Category");
           Console.WriteLine("Testing TransactionCategoryLogic insert: " + transactioncategory.ToString()  );
  
            TransactionCategoryLogic.update(lastId, transactioncategory);

            
          
        }

       
    }
}

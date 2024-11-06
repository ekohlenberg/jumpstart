using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;

namespace legr
{


    public partial class BudgetTest : BaseTest
    {
        
        public static void testInsert()
        {
            Budget budget = new Budget();

            					budget.org_id = BaseTest.getLastId( "Org");
 					budget.category_id = BaseTest.getLastId( "Category");
 						budget.amount = (System.Double) BaseTest.getTestData( budget,"NUMERIC(18,4)", TestDataType.random);
 						budget.start_date = (System.DateTime) BaseTest.getTestData( budget,"DATE", TestDataType.random);
 						budget.end_date = (System.DateTime) BaseTest.getTestData( budget,"DATE", TestDataType.random);

           Console.WriteLine("Testing BudgetLogic insert: " + budget.ToString()  );
  
            BudgetLogic.insert(budget);

            BaseTest.addLastId( "Budget", budget.id);
          
        }

    public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Budget");
            Budget budget = BudgetLogic.get(lastId);

            budget.org_id = BaseTest.getLastId( "Org"); budget.category_id = BaseTest.getLastId( "Category"); budget.amount = (System.Double) BaseTest.getTestData( budget,"NUMERIC(18,4)", TestDataType.random); budget.start_date = (System.DateTime) BaseTest.getTestData( budget,"DATE", TestDataType.random); budget.end_date = (System.DateTime) BaseTest.getTestData( budget,"DATE", TestDataType.random);
           Console.WriteLine("Testing BudgetLogic insert: " + budget.ToString()  );
  
            BudgetLogic.update(lastId, budget);

            
          
        }

       
    }
}

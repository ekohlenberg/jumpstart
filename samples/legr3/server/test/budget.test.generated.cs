using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class BudgetTest : BaseTest
    {
        public static void testInsert()
        {
            var budget = new Budget();


                    budget.org_id = BaseTest.getLastId("Org");
                    
                    budget.category_id = BaseTest.getLastId("Category");
                    
                    budget.amount = Convert.ToDouble(BaseTest.getTestData(budget, "NUMERIC(18,4)", TestDataType.random));
                    
                    budget.start_date = Convert.ToDateTime(BaseTest.getTestData(budget, "DATE", TestDataType.random));
                    
                    budget.end_date = Convert.ToDateTime(BaseTest.getTestData(budget, "DATE", TestDataType.random));
                    
                Console.WriteLine("Testing BudgetLogic insert: " + budget.ToString());
                BudgetLogic.Create().insert(budget);
                BaseTest.addLastId("Budget", budget.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Budget");
            var budget = BudgetLogic.Create().get(lastId);


                            budget.org_id = BaseTest.getLastId("Org");
                        
                            budget.category_id = BaseTest.getLastId("Category");
                        
                        budget.amount = (object) BaseTest.getTestData(budget, "NUMERIC(18,4)", TestDataType.random);
                    
                        budget.start_date = (DateTime) BaseTest.getTestData(budget, "DATE", TestDataType.random);
                    
                        budget.end_date = (DateTime) BaseTest.getTestData(budget, "DATE", TestDataType.random);
                    
                Console.WriteLine("Testing BudgetLogic update: " + budget.ToString());
                BudgetLogic.Create().update(lastId, budget);
                    }
    }
}

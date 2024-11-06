using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;


namespace legr
{
    public partial class BudgetLogic : Logic
    {
    
        public static List<Budget> select()
        {
            Console.WriteLine("Processing BudgetLogic select List" );

            List<Budget> budgets = [];

            void budgetCallback(System.Data.Common.DbDataReader rdr) 
            {
                Budget budget = [];

                DBPersist.autoAssign(rdr, budget);

                budgets.Add(budget);
            };

            DBPersist.select(budgetCallback, "select * from app.budget");

            return budgets;
        }

        
        public static Budget get(long id)
        {
            Console.WriteLine("Processing BudgetLogic get ID=" + id.ToString());

            Budget budget = [];
            budget.id = id;

            DBPersist.get(budget);

            return budget;
        }

        
        public static void insert( Budget budget)
        {
            Console.WriteLine("Processing BudgetLogic insert: " + budget.ToString()  );

            budget.is_active = "Y";

            DBPersist.insert(budget);
        }

       
        public static void update(long id,  Budget budget)
        {
            Console.WriteLine("Processing BudgetLogic update: ID = " + id.ToString() + "\n" + budget.ToString()  );

            budget.id = id;
            DBPersist.update(budget);
        }

        
        public static void delete(long id)
        {
            Budget budget = get(id);
            budget.is_active = "N";
             DBPersist.update(budget);
        }
    }
}

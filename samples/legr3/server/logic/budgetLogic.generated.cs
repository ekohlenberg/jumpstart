
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class BudgetLogic : BaseLogic
    {
        public static List<Budget> select()
        {
            Console.WriteLine("Processing BudgetLogic select List");

            List<Budget> budgets = new List<Budget>();

            void budgetCallback(System.Data.Common.DbDataReader rdr)
            {
                Budget budget = new Budget();

                DBPersist.autoAssign(rdr, budget);

                budgets.Add(budget);
            };

            DBPersist.select(budgetCallback, $"select * from app.budget");

            return budgets;
        }

        public static Budget get(long id)
        {
            Console.WriteLine($"Processing BudgetLogic get ID={id}");

            Budget budget = new Budget();
            budget.id = id;

            DBPersist.get(budget);

            return budget;
        }

        public static void insert(Budget budget)
        {
            Console.WriteLine($"Processing BudgetLogic insert: {budget}");

            budget.is_active = 1;

            DBPersist.insert(budget);
        }

        public static void update(long id, Budget budget)
        {
            Console.WriteLine($"Processing BudgetLogic update: ID = {id}\n{budget}");

            budget.id = id;
            DBPersist.update(budget);
        }

        public static void delete(long id)
        {
            Budget budget = get(id);
            budget.is_active = 0;
            DBPersist.update(budget);
        }
    }
}
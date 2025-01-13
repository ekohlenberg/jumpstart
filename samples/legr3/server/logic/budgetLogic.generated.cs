
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using legr3;

namespace legr3
{


    public partial class BudgetLogic : BaseLogic, IBudgetLogic
    {


        public static IBudgetLogic Create()
        {

            var budget = new BudgetLogic();
            var proxy = DispatchProxy.Create<IBudgetLogic, Proxy<IBudgetLogic>>();
            ((Proxy<IBudgetLogic>)proxy).Target = budget;
            ((Proxy<IBudgetLogic>)proxy).BeforeAction = () => Console.WriteLine("Before method call");
            ((Proxy<IBudgetLogic>)proxy).AfterAction = () => Console.WriteLine("After method call");

            //proxy.PerformAction();
            return proxy;
        }

        public  List<Budget> select()
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

        public  Budget get(long id)
        {
            Console.WriteLine($"Processing BudgetLogic get ID={id}");

            Budget budget = new Budget();
            budget.id = id;

            DBPersist.get(budget);

            return budget;
        }

        public  void insert(Budget budget)
        {
            Console.WriteLine($"Processing BudgetLogic insert: {budget}");

            budget.is_active = 1;

            DBPersist.insert(budget);
        }

        public  void update(long id, Budget budget)
        {
            Console.WriteLine($"Processing BudgetLogic update: ID = {id}\n{budget}");

            budget.id = id;
            DBPersist.update(budget);
        }

        public  void delete(long id)
        {
            Budget budget = get(id);
            budget.is_active = 0;
            DBPersist.update(budget);
        }
    }
}

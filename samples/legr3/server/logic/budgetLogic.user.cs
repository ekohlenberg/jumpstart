
using System;


namespace legr3
{
    public interface IBudgetLogic
    {
        List<Budget> select();
        Budget get(long id);
        void insert(Budget budget);
        void update(long id, Budget budget);
        void delete( long id );
    }


    public partial class BudgetLogic
    {
        public BudgetLogic()
        {
           
        }
        
    }
}


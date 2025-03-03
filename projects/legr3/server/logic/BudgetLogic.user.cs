
using System;


namespace legr3
{
    public interface IBudgetLogic
    {  
        // Generated methods
        List<Budget> select();
        Budget get(long id);
        void insert(Budget budget);
        void update(long id, Budget budget);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class BudgetLogic
    {
        public BudgetLogic()
        {
           
        }
        
    }
}



using System;


namespace legr3
{
    public interface IBillLogic
    {  
        // Generated methods
        List<Bill> select();
        Bill get(long id);
        void insert(Bill bill);
        void update(long id, Bill bill);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class BillLogic
    {
        public BillLogic()
        {
           
        }
        
    }
}


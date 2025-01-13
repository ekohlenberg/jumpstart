
using System;


namespace legr3
{
    public interface IBillLogic
    {
        List<Bill> select();
        Bill get(long id);
        void insert(Bill bill);
        void update(long id, Bill bill);
        void delete( long id );
    }


    public partial class BillLogic
    {
        public BillLogic()
        {
           
        }
        
    }
}


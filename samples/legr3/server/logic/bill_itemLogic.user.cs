
using System;


namespace legr3
{
    public interface IBillItemLogic
    {
        List<BillItem> select();
        BillItem get(long id);
        void insert(BillItem billitem);
        void update(long id, BillItem billitem);
        void delete( long id );
    }


    public partial class BillItemLogic
    {
        public BillItemLogic()
        {
           
        }
        
    }
}


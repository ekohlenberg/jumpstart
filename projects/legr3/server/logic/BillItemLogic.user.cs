
using System;


namespace legr3
{
    public interface IBillItemLogic
    {  
        // Generated methods
        List<BillItem> select();
        BillItem get(long id);
        void insert(BillItem billitem);
        void update(long id, BillItem billitem);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class BillItemLogic
    {
        public BillItemLogic()
        {
           
        }
        
    }
}


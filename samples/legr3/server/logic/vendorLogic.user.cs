
using System;


namespace legr3
{
    public interface IVendorLogic
    {
        List<Vendor> select();
        Vendor get(long id);
        void insert(Vendor vendor);
        void update(long id, Vendor vendor);
        void delete( long id );
    }


    public partial class VendorLogic
    {
        public VendorLogic()
        {
           
        }
        
    }
}


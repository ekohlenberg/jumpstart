
using System;


namespace legr3
{
    public interface IVendorLogic
    {  
        // Generated methods
        List<Vendor> select();
        Vendor get(long id);
        void insert(Vendor vendor);
        void update(long id, Vendor vendor);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class VendorLogic
    {
        public VendorLogic()
        {
           
        }
        
    }
}


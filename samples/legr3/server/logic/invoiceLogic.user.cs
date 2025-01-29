
using System;


namespace legr3
{
    public interface IInvoiceLogic
    {  
        // Generated methods
        List<Invoice> select();
        Invoice get(long id);
        void insert(Invoice invoice);
        void update(long id, Invoice invoice);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class InvoiceLogic
    {
        public InvoiceLogic()
        {
           
        }
        
    }
}


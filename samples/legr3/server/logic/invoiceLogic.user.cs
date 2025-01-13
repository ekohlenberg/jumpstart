
using System;


namespace legr3
{
    public interface IInvoiceLogic
    {
        List<Invoice> select();
        Invoice get(long id);
        void insert(Invoice invoice);
        void update(long id, Invoice invoice);
        void delete( long id );
    }


    public partial class InvoiceLogic
    {
        public InvoiceLogic()
        {
           
        }
        
    }
}



using System;


namespace legr3
{
    public interface IInvoiceItemLogic
    {  
        // Generated methods
        List<InvoiceItem> select();
        InvoiceItem get(long id);
        void insert(InvoiceItem invoiceitem);
        void update(long id, InvoiceItem invoiceitem);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class InvoiceItemLogic
    {
        public InvoiceItemLogic()
        {
           
        }
        
    }
}


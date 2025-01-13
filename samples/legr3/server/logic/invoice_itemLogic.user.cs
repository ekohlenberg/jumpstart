
using System;


namespace legr3
{
    public interface IInvoiceItemLogic
    {
        List<InvoiceItem> select();
        InvoiceItem get(long id);
        void insert(InvoiceItem invoiceitem);
        void update(long id, InvoiceItem invoiceitem);
        void delete( long id );
    }


    public partial class InvoiceItemLogic
    {
        public InvoiceItemLogic()
        {
           
        }
        
    }
}


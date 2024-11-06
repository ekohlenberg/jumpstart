using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;


namespace legr
{
    public partial class InvoiceLogic : Logic
    {
    
        public static List<Invoice> select()
        {
            Console.WriteLine("Processing InvoiceLogic select List" );

            List<Invoice> invoices = [];

            void invoiceCallback(System.Data.Common.DbDataReader rdr) 
            {
                Invoice invoice = [];

                DBPersist.autoAssign(rdr, invoice);

                invoices.Add(invoice);
            };

            DBPersist.select(invoiceCallback, "select * from app.invoice");

            return invoices;
        }

        
        public static Invoice get(long id)
        {
            Console.WriteLine("Processing InvoiceLogic get ID=" + id.ToString());

            Invoice invoice = [];
            invoice.id = id;

            DBPersist.get(invoice);

            return invoice;
        }

        
        public static void insert( Invoice invoice)
        {
            Console.WriteLine("Processing InvoiceLogic insert: " + invoice.ToString()  );

            invoice.is_active = "Y";

            DBPersist.insert(invoice);
        }

       
        public static void update(long id,  Invoice invoice)
        {
            Console.WriteLine("Processing InvoiceLogic update: ID = " + id.ToString() + "\n" + invoice.ToString()  );

            invoice.id = id;
            DBPersist.update(invoice);
        }

        
        public static void delete(long id)
        {
            Invoice invoice = get(id);
            invoice.is_active = "N";
             DBPersist.update(invoice);
        }
    }
}

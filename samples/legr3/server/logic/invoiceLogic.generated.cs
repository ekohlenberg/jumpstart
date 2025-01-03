
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class InvoiceLogic : BaseLogic
    {
        public static List<Invoice> select()
        {
            Console.WriteLine("Processing InvoiceLogic select List");

            List<Invoice> invoices = new List<Invoice>();

            void invoiceCallback(System.Data.Common.DbDataReader rdr)
            {
                Invoice invoice = new Invoice();

                DBPersist.autoAssign(rdr, invoice);

                invoices.Add(invoice);
            };

            DBPersist.select(invoiceCallback, $"select * from app.invoice");

            return invoices;
        }

        public static Invoice get(long id)
        {
            Console.WriteLine($"Processing InvoiceLogic get ID={id}");

            Invoice invoice = new Invoice();
            invoice.id = id;

            DBPersist.get(invoice);

            return invoice;
        }

        public static void insert(Invoice invoice)
        {
            Console.WriteLine($"Processing InvoiceLogic insert: {invoice}");

            invoice.is_active = 1;

            DBPersist.insert(invoice);
        }

        public static void update(long id, Invoice invoice)
        {
            Console.WriteLine($"Processing InvoiceLogic update: ID = {id}\n{invoice}");

            invoice.id = id;
            DBPersist.update(invoice);
        }

        public static void delete(long id)
        {
            Invoice invoice = get(id);
            invoice.is_active = 0;
            DBPersist.update(invoice);
        }
    }
}
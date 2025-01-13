
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using legr3;

namespace legr3
{


    public partial class InvoiceItemLogic : BaseLogic, IInvoiceItemLogic
    {


        public static IInvoiceItemLogic Create()
        {

            var invoiceitem = new InvoiceItemLogic();
            var proxy = DispatchProxy.Create<IInvoiceItemLogic, Proxy<IInvoiceItemLogic>>();
            ((Proxy<IInvoiceItemLogic>)proxy).Target = invoiceitem;
            ((Proxy<IInvoiceItemLogic>)proxy).BeforeAction = () => Console.WriteLine("Before method call");
            ((Proxy<IInvoiceItemLogic>)proxy).AfterAction = () => Console.WriteLine("After method call");

            //proxy.PerformAction();
            return proxy;
        }

        public  List<InvoiceItem> select()
        {
            Console.WriteLine("Processing InvoiceItemLogic select List");

            List<InvoiceItem> invoiceitems = new List<InvoiceItem>();

            void invoiceitemCallback(System.Data.Common.DbDataReader rdr)
            {
                InvoiceItem invoiceitem = new InvoiceItem();

                DBPersist.autoAssign(rdr, invoiceitem);

                invoiceitems.Add(invoiceitem);
            };

            DBPersist.select(invoiceitemCallback, $"select * from app.invoice_item");

            return invoiceitems;
        }

        public  InvoiceItem get(long id)
        {
            Console.WriteLine($"Processing InvoiceItemLogic get ID={id}");

            InvoiceItem invoiceitem = new InvoiceItem();
            invoiceitem.id = id;

            DBPersist.get(invoiceitem);

            return invoiceitem;
        }

        public  void insert(InvoiceItem invoiceitem)
        {
            Console.WriteLine($"Processing InvoiceItemLogic insert: {invoiceitem}");

            invoiceitem.is_active = 1;

            DBPersist.insert(invoiceitem);
        }

        public  void update(long id, InvoiceItem invoiceitem)
        {
            Console.WriteLine($"Processing InvoiceItemLogic update: ID = {id}\n{invoiceitem}");

            invoiceitem.id = id;
            DBPersist.update(invoiceitem);
        }

        public  void delete(long id)
        {
            InvoiceItem invoiceitem = get(id);
            invoiceitem.is_active = 0;
            DBPersist.update(invoiceitem);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class InvoiceItemTest : BaseTest
    {
        public static void testInsert()
        {
            var invoiceitem = new InvoiceItem();


                            invoiceitem.invoice_id = BaseTest.getLastId("Invoice");
                        
                        invoiceitem.description = Convert.ToString(BaseTest.getTestData(invoiceitem, "VARCHAR", TestDataType.random));
                    
                        invoiceitem.quantity = Convert.ToInt32(BaseTest.getTestData(invoiceitem, "INTEGER", TestDataType.random));
                    
                        invoiceitem.unit_price = Convert.ToDouble(BaseTest.getTestData(invoiceitem, "NUMERIC(18,4)", TestDataType.random));
                    
                        invoiceitem.total_amount = Convert.ToDouble(BaseTest.getTestData(invoiceitem, "NUMERIC(18,4)", TestDataType.random));
                    
                Console.WriteLine("Testing InvoiceItemLogic insert: " + invoiceitem.ToString());
                InvoiceItemLogic.insert(invoiceitem);
                BaseTest.addLastId("InvoiceItem", invoiceitem.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("InvoiceItem");
            var invoiceitem = InvoiceItemLogic.get(lastId);


                            invoiceitem.invoice_id = BaseTest.getLastId("Invoice");
                        
                        invoiceitem.description = (string) BaseTest.getTestData(invoiceitem, "VARCHAR", TestDataType.random);
                    
                        invoiceitem.quantity = (int) BaseTest.getTestData(invoiceitem, "INTEGER", TestDataType.random);
                    
                        invoiceitem.unit_price = (object) BaseTest.getTestData(invoiceitem, "NUMERIC(18,4)", TestDataType.random);
                    
                        invoiceitem.total_amount = (object) BaseTest.getTestData(invoiceitem, "NUMERIC(18,4)", TestDataType.random);
                    
                Console.WriteLine("Testing InvoiceItemLogic update: " + invoiceitem.ToString());
                InvoiceItemLogic.update(lastId, invoiceitem);
                    }
    }
}

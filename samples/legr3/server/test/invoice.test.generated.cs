using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class InvoiceTest : BaseTest
    {
        public static void testInsert()
        {
            var invoice = new Invoice();


                    invoice.customer_id = BaseTest.getLastId("Customer");
                    
                    invoice.org_id = BaseTest.getLastId("Org");
                    
                    invoice.invoice_number = Convert.ToInt64(BaseTest.getTestData(invoice, "BIGINT", TestDataType.random));
                    
                    invoice.invoice_date = Convert.ToDateTime(BaseTest.getTestData(invoice, "TIMESTAMP", TestDataType.random));
                    
                    invoice.due_date = Convert.ToDateTime(BaseTest.getTestData(invoice, "TIMESTAMP", TestDataType.random));
                    
                    invoice.total_amount = Convert.ToDouble(BaseTest.getTestData(invoice, "NUMERIC(18,4)", TestDataType.random));
                    
                    invoice.status = Convert.ToString(BaseTest.getTestData(invoice, "VARCHAR", TestDataType.random));
                    
                    invoice.created_date = Convert.ToDateTime(BaseTest.getTestData(invoice, "TIMESTAMP", TestDataType.random));
                    
                Console.WriteLine("Testing InvoiceLogic insert: " + invoice.ToString());
                InvoiceLogic.Create().insert(invoice);
                BaseTest.addLastId("Invoice", invoice.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Invoice");
            var invoice = InvoiceLogic.Create().get(lastId);


                            invoice.customer_id = BaseTest.getLastId("Customer");
                        
                            invoice.org_id = BaseTest.getLastId("Org");
                        
                        invoice.invoice_number = (long) BaseTest.getTestData(invoice, "BIGINT", TestDataType.random);
                    
                        invoice.invoice_date = (DateTime) BaseTest.getTestData(invoice, "TIMESTAMP", TestDataType.random);
                    
                        invoice.due_date = (DateTime) BaseTest.getTestData(invoice, "TIMESTAMP", TestDataType.random);
                    
                        invoice.total_amount = (object) BaseTest.getTestData(invoice, "NUMERIC(18,4)", TestDataType.random);
                    
                        invoice.status = (string) BaseTest.getTestData(invoice, "VARCHAR", TestDataType.random);
                    
                        invoice.created_date = (DateTime) BaseTest.getTestData(invoice, "TIMESTAMP", TestDataType.random);
                    
                Console.WriteLine("Testing InvoiceLogic update: " + invoice.ToString());
                InvoiceLogic.Create().update(lastId, invoice);
                    }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;

namespace legr
{


    public partial class InvoiceTest : BaseTest
    {
        
        public static void testInsert()
        {
            Invoice invoice = new Invoice();

            					invoice.customer_id = BaseTest.getLastId( "Customer");
 					invoice.org_id = BaseTest.getLastId( "Org");
 						invoice.invoice_number = (System.Int64) BaseTest.getTestData( invoice,"BIGINT", TestDataType.random);
 						invoice.invoice_date = (System.DateTime) BaseTest.getTestData( invoice,"TIMESTAMP", TestDataType.random);
 						invoice.due_date = (System.DateTime) BaseTest.getTestData( invoice,"TIMESTAMP", TestDataType.random);
 						invoice.total_amount = (System.Double) BaseTest.getTestData( invoice,"NUMERIC(18,4)", TestDataType.random);
 						invoice.status = (System.String) BaseTest.getTestData( invoice,"VARCHAR", TestDataType.random);
 						invoice.created_date = (System.DateTime) BaseTest.getTestData( invoice,"TIMESTAMP", TestDataType.random);

           Console.WriteLine("Testing InvoiceLogic insert: " + invoice.ToString()  );
  
            InvoiceLogic.insert(invoice);

            BaseTest.addLastId( "Invoice", invoice.id);
          
        }

    public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Invoice");
            Invoice invoice = InvoiceLogic.get(lastId);

            invoice.customer_id = BaseTest.getLastId( "Customer"); invoice.org_id = BaseTest.getLastId( "Org"); invoice.invoice_number = (System.Int64) BaseTest.getTestData( invoice,"BIGINT", TestDataType.random); invoice.invoice_date = (System.DateTime) BaseTest.getTestData( invoice,"TIMESTAMP", TestDataType.random); invoice.due_date = (System.DateTime) BaseTest.getTestData( invoice,"TIMESTAMP", TestDataType.random); invoice.total_amount = (System.Double) BaseTest.getTestData( invoice,"NUMERIC(18,4)", TestDataType.random); invoice.status = (System.String) BaseTest.getTestData( invoice,"VARCHAR", TestDataType.random); invoice.created_date = (System.DateTime) BaseTest.getTestData( invoice,"TIMESTAMP", TestDataType.random);
           Console.WriteLine("Testing InvoiceLogic insert: " + invoice.ToString()  );
  
            InvoiceLogic.update(lastId, invoice);

            
          
        }

       
    }
}

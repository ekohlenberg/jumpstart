using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;

namespace legr
{


    public partial class InvoiceItemTest : BaseTest
    {
        
        public static void testInsert()
        {
            InvoiceItem invoiceitem = new InvoiceItem();

            					invoiceitem.invoice_id = BaseTest.getLastId( "Invoice");
 						invoiceitem.description = (System.String) BaseTest.getTestData( invoiceitem,"VARCHAR", TestDataType.random);
 						invoiceitem.quantity = (System.Int32) BaseTest.getTestData( invoiceitem,"INTEGER", TestDataType.random);
 						invoiceitem.unit_price = (System.Double) BaseTest.getTestData( invoiceitem,"NUMERIC(18,4)", TestDataType.random);
 						invoiceitem.total_amount = (System.Double) BaseTest.getTestData( invoiceitem,"NUMERIC(18,4)", TestDataType.random);

           Console.WriteLine("Testing InvoiceItemLogic insert: " + invoiceitem.ToString()  );
  
            InvoiceItemLogic.insert(invoiceitem);

            BaseTest.addLastId( "InvoiceItem", invoiceitem.id);
          
        }

    public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("InvoiceItem");
            InvoiceItem invoiceitem = InvoiceItemLogic.get(lastId);

            invoiceitem.invoice_id = BaseTest.getLastId( "Invoice"); invoiceitem.description = (System.String) BaseTest.getTestData( invoiceitem,"VARCHAR", TestDataType.random); invoiceitem.quantity = (System.Int32) BaseTest.getTestData( invoiceitem,"INTEGER", TestDataType.random); invoiceitem.unit_price = (System.Double) BaseTest.getTestData( invoiceitem,"NUMERIC(18,4)", TestDataType.random); invoiceitem.total_amount = (System.Double) BaseTest.getTestData( invoiceitem,"NUMERIC(18,4)", TestDataType.random);
           Console.WriteLine("Testing InvoiceItemLogic insert: " + invoiceitem.ToString()  );
  
            InvoiceItemLogic.update(lastId, invoiceitem);

            
          
        }

       
    }
}

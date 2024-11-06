using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;

namespace legr
{


    public partial class PaymentTest : BaseTest
    {
        
        public static void testInsert()
        {
            Payment payment = new Payment();

            					payment.invoice_id = BaseTest.getLastId( "Invoice");
 					payment.org_id = BaseTest.getLastId( "Org");
 						payment.payment_date = (System.DateTime) BaseTest.getTestData( payment,"TIMESTAMP", TestDataType.random);
 						payment.amount = (System.Double) BaseTest.getTestData( payment,"NUMERIC(18,4)", TestDataType.random);
 						payment.payment_method = (System.String) BaseTest.getTestData( payment,"VARCHAR", TestDataType.random);
 						payment.created_date = (System.DateTime) BaseTest.getTestData( payment,"TIMESTAMP", TestDataType.random);

           Console.WriteLine("Testing PaymentLogic insert: " + payment.ToString()  );
  
            PaymentLogic.insert(payment);

            BaseTest.addLastId( "Payment", payment.id);
          
        }

    public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Payment");
            Payment payment = PaymentLogic.get(lastId);

            payment.invoice_id = BaseTest.getLastId( "Invoice"); payment.org_id = BaseTest.getLastId( "Org"); payment.payment_date = (System.DateTime) BaseTest.getTestData( payment,"TIMESTAMP", TestDataType.random); payment.amount = (System.Double) BaseTest.getTestData( payment,"NUMERIC(18,4)", TestDataType.random); payment.payment_method = (System.String) BaseTest.getTestData( payment,"VARCHAR", TestDataType.random); payment.created_date = (System.DateTime) BaseTest.getTestData( payment,"TIMESTAMP", TestDataType.random);
           Console.WriteLine("Testing PaymentLogic insert: " + payment.ToString()  );
  
            PaymentLogic.update(lastId, payment);

            
          
        }

       
    }
}

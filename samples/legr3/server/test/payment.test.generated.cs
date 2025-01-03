using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class PaymentTest : BaseTest
    {
        public static void testInsert()
        {
            var payment = new Payment();


                            payment.invoice_id = BaseTest.getLastId("Invoice");
                        
                            payment.org_id = BaseTest.getLastId("Org");
                        
                        payment.payment_date = Convert.ToDateTime(BaseTest.getTestData(payment, "TIMESTAMP", TestDataType.random));
                    
                        payment.amount = Convert.ToDouble(BaseTest.getTestData(payment, "NUMERIC(18,4)", TestDataType.random));
                    
                        payment.payment_method = Convert.ToString(BaseTest.getTestData(payment, "VARCHAR", TestDataType.random));
                    
                        payment.created_date = Convert.ToDateTime(BaseTest.getTestData(payment, "TIMESTAMP", TestDataType.random));
                    
                Console.WriteLine("Testing PaymentLogic insert: " + payment.ToString());
                PaymentLogic.insert(payment);
                BaseTest.addLastId("Payment", payment.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Payment");
            var payment = PaymentLogic.get(lastId);


                            payment.invoice_id = BaseTest.getLastId("Invoice");
                        
                            payment.org_id = BaseTest.getLastId("Org");
                        
                        payment.payment_date = (DateTime) BaseTest.getTestData(payment, "TIMESTAMP", TestDataType.random);
                    
                        payment.amount = (object) BaseTest.getTestData(payment, "NUMERIC(18,4)", TestDataType.random);
                    
                        payment.payment_method = (string) BaseTest.getTestData(payment, "VARCHAR", TestDataType.random);
                    
                        payment.created_date = (DateTime) BaseTest.getTestData(payment, "TIMESTAMP", TestDataType.random);
                    
                Console.WriteLine("Testing PaymentLogic update: " + payment.ToString());
                PaymentLogic.update(lastId, payment);
                    }
    }
}

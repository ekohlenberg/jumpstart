using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;


namespace legr
{
    public partial class PaymentLogic : Logic
    {
    
        public static List<Payment> select()
        {
            Console.WriteLine("Processing PaymentLogic select List" );

            List<Payment> payments = [];

            void paymentCallback(System.Data.Common.DbDataReader rdr) 
            {
                Payment payment = [];

                DBPersist.autoAssign(rdr, payment);

                payments.Add(payment);
            };

            DBPersist.select(paymentCallback, "select * from app.payment");

            return payments;
        }

        
        public static Payment get(long id)
        {
            Console.WriteLine("Processing PaymentLogic get ID=" + id.ToString());

            Payment payment = [];
            payment.id = id;

            DBPersist.get(payment);

            return payment;
        }

        
        public static void insert( Payment payment)
        {
            Console.WriteLine("Processing PaymentLogic insert: " + payment.ToString()  );

            payment.is_active = "Y";

            DBPersist.insert(payment);
        }

       
        public static void update(long id,  Payment payment)
        {
            Console.WriteLine("Processing PaymentLogic update: ID = " + id.ToString() + "\n" + payment.ToString()  );

            payment.id = id;
            DBPersist.update(payment);
        }

        
        public static void delete(long id)
        {
            Payment payment = get(id);
            payment.is_active = "N";
             DBPersist.update(payment);
        }
    }
}

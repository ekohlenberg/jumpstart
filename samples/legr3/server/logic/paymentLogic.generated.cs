
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class PaymentLogic : BaseLogic
    {
        public static List<Payment> select()
        {
            Console.WriteLine("Processing PaymentLogic select List");

            List<Payment> payments = new List<Payment>();

            void paymentCallback(System.Data.Common.DbDataReader rdr)
            {
                Payment payment = new Payment();

                DBPersist.autoAssign(rdr, payment);

                payments.Add(payment);
            };

            DBPersist.select(paymentCallback, $"select * from app.payment");

            return payments;
        }

        public static Payment get(long id)
        {
            Console.WriteLine($"Processing PaymentLogic get ID={id}");

            Payment payment = new Payment();
            payment.id = id;

            DBPersist.get(payment);

            return payment;
        }

        public static void insert(Payment payment)
        {
            Console.WriteLine($"Processing PaymentLogic insert: {payment}");

            payment.is_active = 1;

            DBPersist.insert(payment);
        }

        public static void update(long id, Payment payment)
        {
            Console.WriteLine($"Processing PaymentLogic update: ID = {id}\n{payment}");

            payment.id = id;
            DBPersist.update(payment);
        }

        public static void delete(long id)
        {
            Payment payment = get(id);
            payment.is_active = 0;
            DBPersist.update(payment);
        }
    }
}

using System;


namespace legr3
{
    public interface IPaymentLogic
    {
        List<Payment> select();
        Payment get(long id);
        void insert(Payment payment);
        void update(long id, Payment payment);
        void delete( long id );
    }


    public partial class PaymentLogic
    {
        public PaymentLogic()
        {
           
        }
        
    }
}


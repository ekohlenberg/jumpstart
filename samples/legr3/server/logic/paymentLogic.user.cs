
using System;


namespace legr3
{
    public interface IPaymentLogic
    {  
        // Generated methods
        List<Payment> select();
        Payment get(long id);
        void insert(Payment payment);
        void update(long id, Payment payment);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class PaymentLogic
    {
        public PaymentLogic()
        {
           
        }
        
    }
}


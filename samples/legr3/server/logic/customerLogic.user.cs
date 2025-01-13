
using System;


namespace legr3
{
    public interface ICustomerLogic
    {
        List<Customer> select();
        Customer get(long id);
        void insert(Customer customer);
        void update(long id, Customer customer);
        void delete( long id );
    }


    public partial class CustomerLogic
    {
        public CustomerLogic()
        {
           
        }
        
    }
}


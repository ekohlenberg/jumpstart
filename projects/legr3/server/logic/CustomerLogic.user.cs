
using System;


namespace legr3
{
    public interface ICustomerLogic
    {  
        // Generated methods
        List<Customer> select();
        Customer get(long id);
        void insert(Customer customer);
        void update(long id, Customer customer);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class CustomerLogic
    {
        public CustomerLogic()
        {
           
        }
        
    }
}


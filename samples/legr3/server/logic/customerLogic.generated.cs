
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using legr3;

namespace legr3
{


    public partial class CustomerLogic : BaseLogic, ICustomerLogic
    {


        public static ICustomerLogic Create()
        {

            var customer = new CustomerLogic();
            var proxy = DispatchProxy.Create<ICustomerLogic, Proxy<ICustomerLogic>>();
            ((Proxy<ICustomerLogic>)proxy).Target = customer;
            ((Proxy<ICustomerLogic>)proxy).BeforeAction = () => Console.WriteLine("Before method call");
            ((Proxy<ICustomerLogic>)proxy).AfterAction = () => Console.WriteLine("After method call");

            //proxy.PerformAction();
            return proxy;
        }

        public  List<Customer> select()
        {
            Console.WriteLine("Processing CustomerLogic select List");

            List<Customer> customers = new List<Customer>();

            void customerCallback(System.Data.Common.DbDataReader rdr)
            {
                Customer customer = new Customer();

                DBPersist.autoAssign(rdr, customer);

                customers.Add(customer);
            };

            DBPersist.select(customerCallback, $"select * from app.customer");

            return customers;
        }

        public  Customer get(long id)
        {
            Console.WriteLine($"Processing CustomerLogic get ID={id}");

            Customer customer = new Customer();
            customer.id = id;

            DBPersist.get(customer);

            return customer;
        }

        public  void insert(Customer customer)
        {
            Console.WriteLine($"Processing CustomerLogic insert: {customer}");

            customer.is_active = 1;

            DBPersist.insert(customer);
        }

        public  void update(long id, Customer customer)
        {
            Console.WriteLine($"Processing CustomerLogic update: ID = {id}\n{customer}");

            customer.id = id;
            DBPersist.update(customer);
        }

        public  void delete(long id)
        {
            Customer customer = get(id);
            customer.is_active = 0;
            DBPersist.update(customer);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;


namespace legr
{
    public partial class CustomerLogic : Logic
    {
    
        public static List<Customer> select()
        {
            Console.WriteLine("Processing CustomerLogic select List" );

            List<Customer> customers = [];

            void customerCallback(System.Data.Common.DbDataReader rdr) 
            {
                Customer customer = [];

                DBPersist.autoAssign(rdr, customer);

                customers.Add(customer);
            };

            DBPersist.select(customerCallback, "select * from app.customer");

            return customers;
        }

        
        public static Customer get(long id)
        {
            Console.WriteLine("Processing CustomerLogic get ID=" + id.ToString());

            Customer customer = [];
            customer.id = id;

            DBPersist.get(customer);

            return customer;
        }

        
        public static void insert( Customer customer)
        {
            Console.WriteLine("Processing CustomerLogic insert: " + customer.ToString()  );

            customer.is_active = "Y";

            DBPersist.insert(customer);
        }

       
        public static void update(long id,  Customer customer)
        {
            Console.WriteLine("Processing CustomerLogic update: ID = " + id.ToString() + "\n" + customer.ToString()  );

            customer.id = id;
            DBPersist.update(customer);
        }

        
        public static void delete(long id)
        {
            Customer customer = get(id);
            customer.is_active = "N";
             DBPersist.update(customer);
        }
    }
}

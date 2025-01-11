using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class CustomerTest : BaseTest
    {
        public static void testInsert()
        {
            var customer = new Customer();


                    customer.org_id = BaseTest.getLastId("Org");
                    
                    customer.customer_name = Convert.ToString(BaseTest.getTestData(customer, "VARCHAR", TestDataType.companies));
                    
                    customer.first_name = Convert.ToString(BaseTest.getTestData(customer, "VARCHAR", TestDataType.firstnames));
                    
                    customer.last_name = Convert.ToString(BaseTest.getTestData(customer, "VARCHAR", TestDataType.lastnames));
                    
                    customer.email = Convert.ToString(BaseTest.getTestData(customer, "VARCHAR", TestDataType.emailAddresses));
                    
                    customer.phone = Convert.ToString(BaseTest.getTestData(customer, "VARCHAR", TestDataType.phoneNumbers));
                    
                    customer.billing_address = Convert.ToString(BaseTest.getTestData(customer, "VARCHAR", TestDataType.addresses));
                    
                    customer.shipping_address = Convert.ToString(BaseTest.getTestData(customer, "VARCHAR", TestDataType.addresses));
                    
                    customer.created_date = Convert.ToDateTime(BaseTest.getTestData(customer, "TIMESTAMP", TestDataType.random));
                    
                Console.WriteLine("Testing CustomerLogic insert: " + customer.ToString());
                CustomerLogic.insert(customer);
                BaseTest.addLastId("Customer", customer.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Customer");
            var customer = CustomerLogic.get(lastId);


                            customer.org_id = BaseTest.getLastId("Org");
                        
                        customer.customer_name = (string) BaseTest.getTestData(customer, "VARCHAR", TestDataType.companies);
                    
                        customer.first_name = (string) BaseTest.getTestData(customer, "VARCHAR", TestDataType.firstnames);
                    
                        customer.last_name = (string) BaseTest.getTestData(customer, "VARCHAR", TestDataType.lastnames);
                    
                        customer.email = (string) BaseTest.getTestData(customer, "VARCHAR", TestDataType.emailAddresses);
                    
                        customer.phone = (string) BaseTest.getTestData(customer, "VARCHAR", TestDataType.phoneNumbers);
                    
                        customer.billing_address = (string) BaseTest.getTestData(customer, "VARCHAR", TestDataType.addresses);
                    
                        customer.shipping_address = (string) BaseTest.getTestData(customer, "VARCHAR", TestDataType.addresses);
                    
                        customer.created_date = (DateTime) BaseTest.getTestData(customer, "TIMESTAMP", TestDataType.random);
                    
                Console.WriteLine("Testing CustomerLogic update: " + customer.ToString());
                CustomerLogic.update(lastId, customer);
                    }
    }
}

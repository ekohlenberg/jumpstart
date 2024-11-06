using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;

namespace legr
{


    public partial class CustomerTest : BaseTest
    {
        
        public static void testInsert()
        {
            Customer customer = new Customer();

            					customer.org_id = BaseTest.getLastId( "Org");
 						customer.customer_name = (System.String) BaseTest.getTestData( customer,"VARCHAR", TestDataType.companies);
 						customer.first_name = (System.String) BaseTest.getTestData( customer,"VARCHAR", TestDataType.firstnames);
 						customer.last_name = (System.String) BaseTest.getTestData( customer,"VARCHAR", TestDataType.lastnames);
 						customer.email = (System.String) BaseTest.getTestData( customer,"VARCHAR", TestDataType.emailAddresses);
 						customer.phone = (System.String) BaseTest.getTestData( customer,"VARCHAR", TestDataType.phoneNumbers);
 						customer.billing_address = (System.String) BaseTest.getTestData( customer,"VARCHAR", TestDataType.addresses);
 						customer.shipping_address = (System.String) BaseTest.getTestData( customer,"VARCHAR", TestDataType.addresses);
 						customer.created_date = (System.DateTime) BaseTest.getTestData( customer,"TIMESTAMP", TestDataType.random);

           Console.WriteLine("Testing CustomerLogic insert: " + customer.ToString()  );
  
            CustomerLogic.insert(customer);

            BaseTest.addLastId( "Customer", customer.id);
          
        }

    public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Customer");
            Customer customer = CustomerLogic.get(lastId);

            customer.org_id = BaseTest.getLastId( "Org"); customer.customer_name = (System.String) BaseTest.getTestData( customer,"VARCHAR", TestDataType.companies); customer.first_name = (System.String) BaseTest.getTestData( customer,"VARCHAR", TestDataType.firstnames); customer.last_name = (System.String) BaseTest.getTestData( customer,"VARCHAR", TestDataType.lastnames); customer.email = (System.String) BaseTest.getTestData( customer,"VARCHAR", TestDataType.emailAddresses); customer.phone = (System.String) BaseTest.getTestData( customer,"VARCHAR", TestDataType.phoneNumbers); customer.billing_address = (System.String) BaseTest.getTestData( customer,"VARCHAR", TestDataType.addresses); customer.shipping_address = (System.String) BaseTest.getTestData( customer,"VARCHAR", TestDataType.addresses); customer.created_date = (System.DateTime) BaseTest.getTestData( customer,"TIMESTAMP", TestDataType.random);
           Console.WriteLine("Testing CustomerLogic insert: " + customer.ToString()  );
  
            CustomerLogic.update(lastId, customer);

            
          
        }

       
    }
}

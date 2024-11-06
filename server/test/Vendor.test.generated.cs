using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;

namespace legr
{


    public partial class VendorTest : BaseTest
    {
        
        public static void testInsert()
        {
            Vendor vendor = new Vendor();

            					vendor.org_id = BaseTest.getLastId( "Org");
 						vendor.vendor_name = (System.String) BaseTest.getTestData( vendor,"VARCHAR", TestDataType.companies);
 						vendor.first_name = (System.String) BaseTest.getTestData( vendor,"VARCHAR", TestDataType.firstnames);
 						vendor.last_name = (System.String) BaseTest.getTestData( vendor,"VARCHAR", TestDataType.lastnames);
 						vendor.email = (System.String) BaseTest.getTestData( vendor,"VARCHAR", TestDataType.emailAddresses);
 						vendor.phone = (System.String) BaseTest.getTestData( vendor,"VARCHAR", TestDataType.phoneNumbers);
 						vendor.billing_address = (System.String) BaseTest.getTestData( vendor,"VARCHAR", TestDataType.addresses);
 						vendor.created_date = (System.DateTime) BaseTest.getTestData( vendor,"TIMESTAMP", TestDataType.random);

           Console.WriteLine("Testing VendorLogic insert: " + vendor.ToString()  );
  
            VendorLogic.insert(vendor);

            BaseTest.addLastId( "Vendor", vendor.id);
          
        }

    public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Vendor");
            Vendor vendor = VendorLogic.get(lastId);

            vendor.org_id = BaseTest.getLastId( "Org"); vendor.vendor_name = (System.String) BaseTest.getTestData( vendor,"VARCHAR", TestDataType.companies); vendor.first_name = (System.String) BaseTest.getTestData( vendor,"VARCHAR", TestDataType.firstnames); vendor.last_name = (System.String) BaseTest.getTestData( vendor,"VARCHAR", TestDataType.lastnames); vendor.email = (System.String) BaseTest.getTestData( vendor,"VARCHAR", TestDataType.emailAddresses); vendor.phone = (System.String) BaseTest.getTestData( vendor,"VARCHAR", TestDataType.phoneNumbers); vendor.billing_address = (System.String) BaseTest.getTestData( vendor,"VARCHAR", TestDataType.addresses); vendor.created_date = (System.DateTime) BaseTest.getTestData( vendor,"TIMESTAMP", TestDataType.random);
           Console.WriteLine("Testing VendorLogic insert: " + vendor.ToString()  );
  
            VendorLogic.update(lastId, vendor);

            
          
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class VendorTest : BaseTest
    {
        public static void testInsert()
        {
            var vendor = new Vendor();


                    vendor.org_id = BaseTest.getLastId("Org");
                    
                    vendor.vendor_name = Convert.ToString(BaseTest.getTestData(vendor, "VARCHAR", TestDataType.companies));
                    
                    vendor.first_name = Convert.ToString(BaseTest.getTestData(vendor, "VARCHAR", TestDataType.firstnames));
                    
                    vendor.last_name = Convert.ToString(BaseTest.getTestData(vendor, "VARCHAR", TestDataType.lastnames));
                    
                    vendor.email = Convert.ToString(BaseTest.getTestData(vendor, "VARCHAR", TestDataType.emailAddresses));
                    
                    vendor.phone = Convert.ToString(BaseTest.getTestData(vendor, "VARCHAR", TestDataType.phoneNumbers));
                    
                    vendor.billing_address = Convert.ToString(BaseTest.getTestData(vendor, "VARCHAR", TestDataType.addresses));
                    
                    vendor.created_date = Convert.ToDateTime(BaseTest.getTestData(vendor, "TIMESTAMP", TestDataType.random));
                    
                Console.WriteLine("Testing VendorLogic insert: " + vendor.ToString());
                VendorLogic.Create().insert(vendor);
                BaseTest.addLastId("Vendor", vendor.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Vendor");
            var vendor = VendorLogic.Create().get(lastId);


                            vendor.org_id = BaseTest.getLastId("Org");
                        
                        vendor.vendor_name = (string) BaseTest.getTestData(vendor, "VARCHAR", TestDataType.companies);
                    
                        vendor.first_name = (string) BaseTest.getTestData(vendor, "VARCHAR", TestDataType.firstnames);
                    
                        vendor.last_name = (string) BaseTest.getTestData(vendor, "VARCHAR", TestDataType.lastnames);
                    
                        vendor.email = (string) BaseTest.getTestData(vendor, "VARCHAR", TestDataType.emailAddresses);
                    
                        vendor.phone = (string) BaseTest.getTestData(vendor, "VARCHAR", TestDataType.phoneNumbers);
                    
                        vendor.billing_address = (string) BaseTest.getTestData(vendor, "VARCHAR", TestDataType.addresses);
                    
                        vendor.created_date = (DateTime) BaseTest.getTestData(vendor, "TIMESTAMP", TestDataType.random);
                    
                Console.WriteLine("Testing VendorLogic update: " + vendor.ToString());
                VendorLogic.Create().update(lastId, vendor);
                    }
    }
}

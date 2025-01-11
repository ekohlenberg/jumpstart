using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class BillTest : BaseTest
    {
        public static void testInsert()
        {
            var bill = new Bill();


                    bill.vendor_id = BaseTest.getLastId("Vendor");
                    
                    bill.org_id = BaseTest.getLastId("Org");
                    
                    bill.bill_number = Convert.ToInt64(BaseTest.getTestData(bill, "BIGINT", TestDataType.random));
                    
                    bill.bill_date = Convert.ToDateTime(BaseTest.getTestData(bill, "TIMESTAMP", TestDataType.random));
                    
                    bill.due_date = Convert.ToDateTime(BaseTest.getTestData(bill, "TIMESTAMP", TestDataType.random));
                    
                    bill.total_amount = Convert.ToDouble(BaseTest.getTestData(bill, "NUMERIC(18,4)", TestDataType.random));
                    
                    bill.status = Convert.ToString(BaseTest.getTestData(bill, "VARCHAR", TestDataType.random));
                    
                    bill.created_date = Convert.ToDateTime(BaseTest.getTestData(bill, "TIMESTAMP", TestDataType.random));
                    
                Console.WriteLine("Testing BillLogic insert: " + bill.ToString());
                BillLogic.insert(bill);
                BaseTest.addLastId("Bill", bill.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Bill");
            var bill = BillLogic.get(lastId);


                            bill.vendor_id = BaseTest.getLastId("Vendor");
                        
                            bill.org_id = BaseTest.getLastId("Org");
                        
                        bill.bill_number = (long) BaseTest.getTestData(bill, "BIGINT", TestDataType.random);
                    
                        bill.bill_date = (DateTime) BaseTest.getTestData(bill, "TIMESTAMP", TestDataType.random);
                    
                        bill.due_date = (DateTime) BaseTest.getTestData(bill, "TIMESTAMP", TestDataType.random);
                    
                        bill.total_amount = (object) BaseTest.getTestData(bill, "NUMERIC(18,4)", TestDataType.random);
                    
                        bill.status = (string) BaseTest.getTestData(bill, "VARCHAR", TestDataType.random);
                    
                        bill.created_date = (DateTime) BaseTest.getTestData(bill, "TIMESTAMP", TestDataType.random);
                    
                Console.WriteLine("Testing BillLogic update: " + bill.ToString());
                BillLogic.update(lastId, bill);
                    }
    }
}

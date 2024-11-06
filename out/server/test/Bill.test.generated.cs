using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;

namespace legr
{


    public partial class BillTest : BaseTest
    {
        
        public static void testInsert()
        {
            Bill bill = new Bill();

            					bill.vendor_id = BaseTest.getLastId( "Vendor");
 					bill.org_id = BaseTest.getLastId( "Org");
 						bill.bill_number = (System.Int64) BaseTest.getTestData( bill,"BIGINT", TestDataType.random);
 						bill.bill_date = (System.DateTime) BaseTest.getTestData( bill,"TIMESTAMP", TestDataType.random);
 						bill.due_date = (System.DateTime) BaseTest.getTestData( bill,"TIMESTAMP", TestDataType.random);
 						bill.total_amount = (System.Double) BaseTest.getTestData( bill,"NUMERIC(18,4)", TestDataType.random);
 						bill.status = (System.String) BaseTest.getTestData( bill,"VARCHAR", TestDataType.random);
 						bill.created_date = (System.DateTime) BaseTest.getTestData( bill,"TIMESTAMP", TestDataType.random);

           Console.WriteLine("Testing BillLogic insert: " + bill.ToString()  );
  
            BillLogic.insert(bill);

            BaseTest.addLastId( "Bill", bill.id);
          
        }

    public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Bill");
            Bill bill = BillLogic.get(lastId);

            bill.vendor_id = BaseTest.getLastId( "Vendor"); bill.org_id = BaseTest.getLastId( "Org"); bill.bill_number = (System.Int64) BaseTest.getTestData( bill,"BIGINT", TestDataType.random); bill.bill_date = (System.DateTime) BaseTest.getTestData( bill,"TIMESTAMP", TestDataType.random); bill.due_date = (System.DateTime) BaseTest.getTestData( bill,"TIMESTAMP", TestDataType.random); bill.total_amount = (System.Double) BaseTest.getTestData( bill,"NUMERIC(18,4)", TestDataType.random); bill.status = (System.String) BaseTest.getTestData( bill,"VARCHAR", TestDataType.random); bill.created_date = (System.DateTime) BaseTest.getTestData( bill,"TIMESTAMP", TestDataType.random);
           Console.WriteLine("Testing BillLogic insert: " + bill.ToString()  );
  
            BillLogic.update(lastId, bill);

            
          
        }

       
    }
}

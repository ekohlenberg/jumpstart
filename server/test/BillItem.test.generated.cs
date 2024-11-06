using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;

namespace legr
{


    public partial class BillItemTest : BaseTest
    {
        
        public static void testInsert()
        {
            BillItem billitem = new BillItem();

            					billitem.bill_id = BaseTest.getLastId( "Bill");
 						billitem.description = (System.String) BaseTest.getTestData( billitem,"VARCHAR", TestDataType.random);
 						billitem.quantity = (System.Int32) BaseTest.getTestData( billitem,"INTEGER", TestDataType.random);
 						billitem.unit_price = (System.Double) BaseTest.getTestData( billitem,"NUMERIC(18,4)", TestDataType.random);
 						billitem.total_amount = (System.Double) BaseTest.getTestData( billitem,"NUMERIC(18,4)", TestDataType.random);

           Console.WriteLine("Testing BillItemLogic insert: " + billitem.ToString()  );
  
            BillItemLogic.insert(billitem);

            BaseTest.addLastId( "BillItem", billitem.id);
          
        }

    public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("BillItem");
            BillItem billitem = BillItemLogic.get(lastId);

            billitem.bill_id = BaseTest.getLastId( "Bill"); billitem.description = (System.String) BaseTest.getTestData( billitem,"VARCHAR", TestDataType.random); billitem.quantity = (System.Int32) BaseTest.getTestData( billitem,"INTEGER", TestDataType.random); billitem.unit_price = (System.Double) BaseTest.getTestData( billitem,"NUMERIC(18,4)", TestDataType.random); billitem.total_amount = (System.Double) BaseTest.getTestData( billitem,"NUMERIC(18,4)", TestDataType.random);
           Console.WriteLine("Testing BillItemLogic insert: " + billitem.ToString()  );
  
            BillItemLogic.update(lastId, billitem);

            
          
        }

       
    }
}

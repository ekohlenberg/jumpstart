using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class BillItemTest : BaseTest
    {
        public static void testInsert()
        {
            var billitem = new BillItem();


                    billitem.bill_id = BaseTest.getLastId("Bill");
                    
                    billitem.description = Convert.ToString(BaseTest.getTestData(billitem, "VARCHAR", TestDataType.random));
                    
                    billitem.quantity = Convert.ToInt32(BaseTest.getTestData(billitem, "INTEGER", TestDataType.random));
                    
                    billitem.unit_price = Convert.ToDouble(BaseTest.getTestData(billitem, "NUMERIC(18,4)", TestDataType.random));
                    
                    billitem.total_amount = Convert.ToDouble(BaseTest.getTestData(billitem, "NUMERIC(18,4)", TestDataType.random));
                    
                Console.WriteLine("Testing BillItemLogic insert: " + billitem.ToString());
                BillItemLogic.Create().insert(billitem);
                BaseTest.addLastId("BillItem", billitem.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("BillItem");
            var billitem = BillItemLogic.Create().get(lastId);


                            billitem.bill_id = BaseTest.getLastId("Bill");
                        
                        billitem.description = (string) BaseTest.getTestData(billitem, "VARCHAR", TestDataType.random);
                    
                        billitem.quantity = (int) BaseTest.getTestData(billitem, "INTEGER", TestDataType.random);
                    
                        billitem.unit_price = (object) BaseTest.getTestData(billitem, "NUMERIC(18,4)", TestDataType.random);
                    
                        billitem.total_amount = (object) BaseTest.getTestData(billitem, "NUMERIC(18,4)", TestDataType.random);
                    
                Console.WriteLine("Testing BillItemLogic update: " + billitem.ToString());
                BillItemLogic.Create().update(lastId, billitem);
                    }
    }
}

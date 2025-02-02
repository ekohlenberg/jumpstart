using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class UomTest : BaseTest
    {
        public static void testInsert()
        {
            var uom = new Uom();


                    uom.Name = Convert.ToString(BaseTest.getTestData(uom, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing UomLogic insert: " + uom.ToString());
                UomLogic.Create().insert(uom);
                BaseTest.addLastId("uom", uom.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Uom");
            var uom = UomLogic.Create().get(lastId);


                        uom.Name = (string) BaseTest.getTestData(uom, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing UomLogic update: " + uom.ToString());
                UomLogic.Create().update(lastId, uom);
                    }
    }
}

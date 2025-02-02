using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class OpRoleTest : BaseTest
    {
        public static void testInsert()
        {
            var oprole = new OpRole();


                    oprole.name = Convert.ToString(BaseTest.getTestData(oprole, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing OpRoleLogic insert: " + oprole.ToString());
                OpRoleLogic.Create().insert(oprole);
                BaseTest.addLastId("op_role", oprole.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("OpRole");
            var oprole = OpRoleLogic.Create().get(lastId);


                        oprole.name = (string) BaseTest.getTestData(oprole, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing OpRoleLogic update: " + oprole.ToString());
                OpRoleLogic.Create().update(lastId, oprole);
                    }
    }
}

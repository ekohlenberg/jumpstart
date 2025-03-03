using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class OpRoleMapTest : BaseTest
    {
        public static void testInsert()
        {
            var oprolemap = new OpRoleMap();


                    oprolemap.op_id = BaseTest.getLastId("operation");
                    
                    oprolemap.op_role_id = BaseTest.getLastId("op_role");
                    
                Console.WriteLine("Testing OpRoleMapLogic insert: " + oprolemap.ToString());
                OpRoleMapLogic.Create().insert(oprolemap);
                BaseTest.addLastId("op_role_map", oprolemap.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("OpRoleMap");
            var oprolemap = OpRoleMapLogic.Create().get(lastId);


                            oprolemap.op_id = BaseTest.getLastId("operation");
                        
                            oprolemap.op_role_id = BaseTest.getLastId("op_role");
                        
                Console.WriteLine("Testing OpRoleMapLogic update: " + oprolemap.ToString());
                OpRoleMapLogic.Create().update(lastId, oprolemap);
                    }
    }
}

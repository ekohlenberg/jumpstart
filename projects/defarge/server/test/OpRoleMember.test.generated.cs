using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class OpRoleMemberTest : BaseTest
    {
        public static void testInsert()
        {
            var oprolemember = new OpRoleMember();


                    oprolemember.user_id = BaseTest.getLastId("user");
                    
                    oprolemember.op_role_id = BaseTest.getLastId("op_role");
                    
                Console.WriteLine("Testing OpRoleMemberLogic insert: " + oprolemember.ToString());
                OpRoleMemberLogic.Create().insert(oprolemember);
                BaseTest.addLastId("op_role_member", oprolemember.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("OpRoleMember");
            var oprolemember = OpRoleMemberLogic.Create().get(lastId);


                            oprolemember.user_id = BaseTest.getLastId("user");
                        
                            oprolemember.op_role_id = BaseTest.getLastId("op_role");
                        
                Console.WriteLine("Testing OpRoleMemberLogic update: " + oprolemember.ToString());
                OpRoleMemberLogic.Create().update(lastId, oprolemember);
                    }
    }
}

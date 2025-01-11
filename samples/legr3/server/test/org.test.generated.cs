using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class OrgTest : BaseTest
    {
        public static void testInsert()
        {
            var org = new Org();


                    org.name = Convert.ToString(BaseTest.getTestData(org, "VARCHAR", TestDataType.companies));
                    
                Console.WriteLine("Testing OrgLogic insert: " + org.ToString());
                OrgLogic.insert(org);
                BaseTest.addLastId("Org", org.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Org");
            var org = OrgLogic.get(lastId);


                        org.name = (string) BaseTest.getTestData(org, "VARCHAR", TestDataType.companies);
                    
                Console.WriteLine("Testing OrgLogic update: " + org.ToString());
                OrgLogic.update(lastId, org);
                    }
    }
}

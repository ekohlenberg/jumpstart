using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;

namespace legr
{


    public partial class OrgTest : BaseTest
    {
        
        public static void testInsert()
        {
            Org org = new Org();

            						org.name = (System.String) BaseTest.getTestData( org,"VARCHAR", TestDataType.companies);

           Console.WriteLine("Testing OrgLogic insert: " + org.ToString()  );
  
            OrgLogic.insert(org);

            BaseTest.addLastId( "Org", org.id);
          
        }

    public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Org");
            Org org = OrgLogic.get(lastId);

            org.name = (System.String) BaseTest.getTestData( org,"VARCHAR", TestDataType.companies);
           Console.WriteLine("Testing OrgLogic insert: " + org.ToString()  );
  
            OrgLogic.update(lastId, org);

            
          
        }

       
    }
}

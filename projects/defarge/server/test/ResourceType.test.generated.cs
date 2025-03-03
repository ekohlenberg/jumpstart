using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ResourceTypeTest : BaseTest
    {
        public static void testInsert()
        {
            var resourcetype = new ResourceType();


                    resourcetype.name = Convert.ToString(BaseTest.getTestData(resourcetype, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing ResourceTypeLogic insert: " + resourcetype.ToString());
                ResourceTypeLogic.Create().insert(resourcetype);
                BaseTest.addLastId("resource_type", resourcetype.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("ResourceType");
            var resourcetype = ResourceTypeLogic.Create().get(lastId);


                        resourcetype.name = (string) BaseTest.getTestData(resourcetype, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing ResourceTypeLogic update: " + resourcetype.ToString());
                ResourceTypeLogic.Create().update(lastId, resourcetype);
                    }
    }
}

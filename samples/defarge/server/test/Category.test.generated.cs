using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class CategoryTest : BaseTest
    {
        public static void testInsert()
        {
            var category = new Category();


                    category.parent_id = BaseTest.getLastId("category");
                    
                    category.name = Convert.ToString(BaseTest.getTestData(category, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing CategoryLogic insert: " + category.ToString());
                CategoryLogic.Create().insert(category);
                BaseTest.addLastId("category", category.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Category");
            var category = CategoryLogic.Create().get(lastId);


                            category.parent_id = BaseTest.getLastId("category");
                        
                        category.name = (string) BaseTest.getTestData(category, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing CategoryLogic update: " + category.ToString());
                CategoryLogic.Create().update(lastId, category);
                    }
    }
}

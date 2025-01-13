using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class CategoryTest : BaseTest
    {
        public static void testInsert()
        {
            var category = new Category();


                    category.org_id = BaseTest.getLastId("Org");
                    
                    category.category_name = Convert.ToString(BaseTest.getTestData(category, "VARCHAR", TestDataType.random));
                    
                    category.category_type = Convert.ToString(BaseTest.getTestData(category, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing CategoryLogic insert: " + category.ToString());
                CategoryLogic.Create().insert(category);
                BaseTest.addLastId("Category", category.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Category");
            var category = CategoryLogic.Create().get(lastId);


                            category.org_id = BaseTest.getLastId("Org");
                        
                        category.category_name = (string) BaseTest.getTestData(category, "VARCHAR", TestDataType.random);
                    
                        category.category_type = (string) BaseTest.getTestData(category, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing CategoryLogic update: " + category.ToString());
                CategoryLogic.Create().update(lastId, category);
                    }
    }
}

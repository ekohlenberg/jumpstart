using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;

namespace legr
{


    public partial class CategoryTest : BaseTest
    {
        
        public static void testInsert()
        {
            Category category = new Category();

            					category.org_id = BaseTest.getLastId( "Org");
 						category.category_name = (System.String) BaseTest.getTestData( category,"VARCHAR", TestDataType.random);
 						category.category_type = (System.String) BaseTest.getTestData( category,"VARCHAR", TestDataType.random);

           Console.WriteLine("Testing CategoryLogic insert: " + category.ToString()  );
  
            CategoryLogic.insert(category);

            BaseTest.addLastId( "Category", category.id);
          
        }

    public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Category");
            Category category = CategoryLogic.get(lastId);

            category.org_id = BaseTest.getLastId( "Org"); category.category_name = (System.String) BaseTest.getTestData( category,"VARCHAR", TestDataType.random); category.category_type = (System.String) BaseTest.getTestData( category,"VARCHAR", TestDataType.random);
           Console.WriteLine("Testing CategoryLogic insert: " + category.ToString()  );
  
            CategoryLogic.update(lastId, category);

            
          
        }

       
    }
}

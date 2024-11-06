using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;


namespace legr
{
    public partial class CategoryLogic : Logic
    {
    
        public static List<Category> select()
        {
            Console.WriteLine("Processing CategoryLogic select List" );

            List<Category> categorys = [];

            void categoryCallback(System.Data.Common.DbDataReader rdr) 
            {
                Category category = [];

                DBPersist.autoAssign(rdr, category);

                categorys.Add(category);
            };

            DBPersist.select(categoryCallback, "select * from app.category");

            return categorys;
        }

        
        public static Category get(long id)
        {
            Console.WriteLine("Processing CategoryLogic get ID=" + id.ToString());

            Category category = [];
            category.id = id;

            DBPersist.get(category);

            return category;
        }

        
        public static void insert( Category category)
        {
            Console.WriteLine("Processing CategoryLogic insert: " + category.ToString()  );

            category.is_active = "Y";

            DBPersist.insert(category);
        }

       
        public static void update(long id,  Category category)
        {
            Console.WriteLine("Processing CategoryLogic update: ID = " + id.ToString() + "\n" + category.ToString()  );

            category.id = id;
            DBPersist.update(category);
        }

        
        public static void delete(long id)
        {
            Category category = get(id);
            category.is_active = "N";
             DBPersist.update(category);
        }
    }
}

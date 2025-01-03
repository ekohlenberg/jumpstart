
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class CategoryLogic : BaseLogic
    {
        public static List<Category> select()
        {
            Console.WriteLine("Processing CategoryLogic select List");

            List<Category> categorys = new List<Category>();

            void categoryCallback(System.Data.Common.DbDataReader rdr)
            {
                Category category = new Category();

                DBPersist.autoAssign(rdr, category);

                categorys.Add(category);
            };

            DBPersist.select(categoryCallback, $"select * from app.category");

            return categorys;
        }

        public static Category get(long id)
        {
            Console.WriteLine($"Processing CategoryLogic get ID={id}");

            Category category = new Category();
            category.id = id;

            DBPersist.get(category);

            return category;
        }

        public static void insert(Category category)
        {
            Console.WriteLine($"Processing CategoryLogic insert: {category}");

            category.is_active = 1;

            DBPersist.insert(category);
        }

        public static void update(long id, Category category)
        {
            Console.WriteLine($"Processing CategoryLogic update: ID = {id}\n{category}");

            category.id = id;
            DBPersist.update(category);
        }

        public static void delete(long id)
        {
            Category category = get(id);
            category.is_active = 0;
            DBPersist.update(category);
        }
    }
}
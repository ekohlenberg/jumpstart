
using System;


namespace legr3
{
    public interface ICategoryLogic
    {
        List<Category> select();
        Category get(long id);
        void insert(Category category);
        void update(long id, Category category);
        void delete( long id );
    }


    public partial class CategoryLogic
    {
        public CategoryLogic()
        {
           
        }
        
    }
}


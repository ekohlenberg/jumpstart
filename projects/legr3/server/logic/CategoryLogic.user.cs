
using System;


namespace legr3
{
    public interface ICategoryLogic
    {  
        // Generated methods
        List<Category> select();
        Category get(long id);
        void insert(Category category);
        void update(long id, Category category);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class CategoryLogic
    {
        public CategoryLogic()
        {
           
        }
        
    }
}


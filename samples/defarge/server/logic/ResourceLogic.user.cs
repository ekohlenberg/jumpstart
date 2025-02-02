
using System;


namespace defarge
{
    public interface IResourceLogic
    {  
        // Generated methods
        List<Resource> select();
        Resource get(long id);
        void insert(Resource resource);
        void update(long id, Resource resource);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ResourceLogic
    {
        public ResourceLogic()
        {
           
        }
        
    }
}


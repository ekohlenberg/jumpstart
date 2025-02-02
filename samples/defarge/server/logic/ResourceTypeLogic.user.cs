
using System;


namespace defarge
{
    public interface IResourceTypeLogic
    {  
        // Generated methods
        List<ResourceType> select();
        ResourceType get(long id);
        void insert(ResourceType resourcetype);
        void update(long id, ResourceType resourcetype);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ResourceTypeLogic
    {
        public ResourceTypeLogic()
        {
           
        }
        
    }
}


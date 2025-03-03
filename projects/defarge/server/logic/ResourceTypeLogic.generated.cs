
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ResourceTypeLogic : IResourceTypeLogic
    {


        public static IResourceTypeLogic Create()
        {
            var resourcetype = new ResourceTypeLogic();

            var proxy = DispatchProxy.Create<IResourceTypeLogic, Proxy<IResourceTypeLogic>>();
            ((Proxy<IResourceTypeLogic>)proxy).Initialize();
            ((Proxy<IResourceTypeLogic>)proxy).Target = resourcetype;
            ((Proxy<IResourceTypeLogic>)proxy).DomainObj = "ResourceType";

            return proxy;
        }



        public  List<ResourceType> select()
        {
            Console.WriteLine("Processing ResourceTypeLogic select List");

            List<ResourceType> resourcetypes = new List<ResourceType>();

            void resourcetypeCallback(System.Data.Common.DbDataReader rdr)
            {
                ResourceType resourcetype = new ResourceType();

                DBPersist.autoAssign(rdr, resourcetype);

                resourcetypes.Add(resourcetype);
            };

            DBPersist.select(resourcetypeCallback, $"select * from app.resource_type");

            return resourcetypes;
        }

        public  ResourceType get(long id)
        {
            Console.WriteLine($"Processing ResourceTypeLogic get ID={id}");

            ResourceType resourcetype = new ResourceType();
            resourcetype.id = id;

            DBPersist.get(resourcetype);

            return resourcetype;
        }

        public  void insert(ResourceType resourcetype)
        {
            Console.WriteLine($"Processing ResourceTypeLogic insert: {resourcetype}");

            resourcetype.is_active = 1;

            DBPersist.insert(resourcetype);
        }

        public  void update(long id, ResourceType resourcetype)
        {
            Console.WriteLine($"Processing ResourceTypeLogic update: ID = {id}\n{resourcetype}");

            resourcetype.id = id;
            DBPersist.update(resourcetype);
        }

        public  void delete(long id)
        {
            ResourceType resourcetype = get(id);
            resourcetype.is_active = 0;
            DBPersist.update(resourcetype);
        }
    }
}

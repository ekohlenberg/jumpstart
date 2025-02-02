
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ResourceLogic : IResourceLogic
    {


        public static IResourceLogic Create()
        {
            var resource = new ResourceLogic();

            var proxy = DispatchProxy.Create<IResourceLogic, Proxy<IResourceLogic>>();
            ((Proxy<IResourceLogic>)proxy).Initialize();
            ((Proxy<IResourceLogic>)proxy).Target = resource;
            ((Proxy<IResourceLogic>)proxy).DomainObj = "Resource";

            return proxy;
        }



        public  List<Resource> select()
        {
            Console.WriteLine("Processing ResourceLogic select List");

            List<Resource> resources = new List<Resource>();

            void resourceCallback(System.Data.Common.DbDataReader rdr)
            {
                Resource resource = new Resource();

                DBPersist.autoAssign(rdr, resource);

                resources.Add(resource);
            };

            DBPersist.select(resourceCallback, $"select * from app.resource");

            return resources;
        }

        public  Resource get(long id)
        {
            Console.WriteLine($"Processing ResourceLogic get ID={id}");

            Resource resource = new Resource();
            resource.id = id;

            DBPersist.get(resource);

            return resource;
        }

        public  void insert(Resource resource)
        {
            Console.WriteLine($"Processing ResourceLogic insert: {resource}");

            resource.is_active = 1;

            DBPersist.insert(resource);
        }

        public  void update(long id, Resource resource)
        {
            Console.WriteLine($"Processing ResourceLogic update: ID = {id}\n{resource}");

            resource.id = id;
            DBPersist.update(resource);
        }

        public  void delete(long id)
        {
            Resource resource = get(id);
            resource.is_active = 0;
            DBPersist.update(resource);
        }
    }
}

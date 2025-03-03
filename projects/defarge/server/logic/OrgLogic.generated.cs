
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class OrgLogic : IOrgLogic
    {


        public static IOrgLogic Create()
        {
            var org = new OrgLogic();

            var proxy = DispatchProxy.Create<IOrgLogic, Proxy<IOrgLogic>>();
            ((Proxy<IOrgLogic>)proxy).Initialize();
            ((Proxy<IOrgLogic>)proxy).Target = org;
            ((Proxy<IOrgLogic>)proxy).DomainObj = "Org";

            return proxy;
        }



        public  List<Org> select()
        {
            Console.WriteLine("Processing OrgLogic select List");

            List<Org> orgs = new List<Org>();

            void orgCallback(System.Data.Common.DbDataReader rdr)
            {
                Org org = new Org();

                DBPersist.autoAssign(rdr, org);

                orgs.Add(org);
            };

            DBPersist.select(orgCallback, $"select * from app.org");

            return orgs;
        }

        public  Org get(long id)
        {
            Console.WriteLine($"Processing OrgLogic get ID={id}");

            Org org = new Org();
            org.id = id;

            DBPersist.get(org);

            return org;
        }

        public  void insert(Org org)
        {
            Console.WriteLine($"Processing OrgLogic insert: {org}");

            org.is_active = 1;

            DBPersist.insert(org);
        }

        public  void update(long id, Org org)
        {
            Console.WriteLine($"Processing OrgLogic update: ID = {id}\n{org}");

            org.id = id;
            DBPersist.update(org);
        }

        public  void delete(long id)
        {
            Org org = get(id);
            org.is_active = 0;
            DBPersist.update(org);
        }
    }
}

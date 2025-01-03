
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class OrgLogic : BaseLogic
    {
        public static List<Org> select()
        {
            Console.WriteLine("Processing OrgLogic select List");

            List<Org> orgs = new List<Org>();

            void orgCallback(System.Data.Common.DbDataReader rdr)
            {
                Org org = new Org();

                DBPersist.autoAssign(rdr, org);

                orgs.Add(org);
            };

            DBPersist.select(orgCallback, $"select * from sec.org");

            return orgs;
        }

        public static Org get(long id)
        {
            Console.WriteLine($"Processing OrgLogic get ID={id}");

            Org org = new Org();
            org.id = id;

            DBPersist.get(org);

            return org;
        }

        public static void insert(Org org)
        {
            Console.WriteLine($"Processing OrgLogic insert: {org}");

            org.is_active = 1;

            DBPersist.insert(org);
        }

        public static void update(long id, Org org)
        {
            Console.WriteLine($"Processing OrgLogic update: ID = {id}\n{org}");

            org.id = id;
            DBPersist.update(org);
        }

        public static void delete(long id)
        {
            Org org = get(id);
            org.is_active = 0;
            DBPersist.update(org);
        }
    }
}
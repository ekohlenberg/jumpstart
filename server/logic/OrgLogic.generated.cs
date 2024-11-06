using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;


namespace legr
{
    public partial class OrgLogic : Logic
    {
    
        public static List<Org> select()
        {
            Console.WriteLine("Processing OrgLogic select List" );

            List<Org> orgs = [];

            void orgCallback(System.Data.Common.DbDataReader rdr) 
            {
                Org org = [];

                DBPersist.autoAssign(rdr, org);

                orgs.Add(org);
            };

            DBPersist.select(orgCallback, "select * from sec.org");

            return orgs;
        }

        
        public static Org get(long id)
        {
            Console.WriteLine("Processing OrgLogic get ID=" + id.ToString());

            Org org = [];
            org.id = id;

            DBPersist.get(org);

            return org;
        }

        
        public static void insert( Org org)
        {
            Console.WriteLine("Processing OrgLogic insert: " + org.ToString()  );

            org.is_active = "Y";

            DBPersist.insert(org);
        }

       
        public static void update(long id,  Org org)
        {
            Console.WriteLine("Processing OrgLogic update: ID = " + id.ToString() + "\n" + org.ToString()  );

            org.id = id;
            DBPersist.update(org);
        }

        
        public static void delete(long id)
        {
            Org org = get(id);
            org.is_active = "N";
             DBPersist.update(org);
        }
    }
}

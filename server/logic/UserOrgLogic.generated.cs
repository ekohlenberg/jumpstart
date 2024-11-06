using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;


namespace legr
{
    public partial class UserOrgLogic : Logic
    {
    
        public static List<UserOrg> select()
        {
            Console.WriteLine("Processing UserOrgLogic select List" );

            List<UserOrg> userorgs = [];

            void userorgCallback(System.Data.Common.DbDataReader rdr) 
            {
                UserOrg userorg = [];

                DBPersist.autoAssign(rdr, userorg);

                userorgs.Add(userorg);
            };

            DBPersist.select(userorgCallback, "select * from sec.user_org");

            return userorgs;
        }

        
        public static UserOrg get(long id)
        {
            Console.WriteLine("Processing UserOrgLogic get ID=" + id.ToString());

            UserOrg userorg = [];
            userorg.id = id;

            DBPersist.get(userorg);

            return userorg;
        }

        
        public static void insert( UserOrg userorg)
        {
            Console.WriteLine("Processing UserOrgLogic insert: " + userorg.ToString()  );

            userorg.is_active = "Y";

            DBPersist.insert(userorg);
        }

       
        public static void update(long id,  UserOrg userorg)
        {
            Console.WriteLine("Processing UserOrgLogic update: ID = " + id.ToString() + "\n" + userorg.ToString()  );

            userorg.id = id;
            DBPersist.update(userorg);
        }

        
        public static void delete(long id)
        {
            UserOrg userorg = get(id);
            userorg.is_active = "N";
             DBPersist.update(userorg);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class UserOrgLogic : BaseLogic
    {
        public static List<UserOrg> select()
        {
            Console.WriteLine("Processing UserOrgLogic select List");

            List<UserOrg> userorgs = new List<UserOrg>();

            void userorgCallback(System.Data.Common.DbDataReader rdr)
            {
                UserOrg userorg = new UserOrg();

                DBPersist.autoAssign(rdr, userorg);

                userorgs.Add(userorg);
            };

            DBPersist.select(userorgCallback, $"select * from sec.user_org");

            return userorgs;
        }

        public static UserOrg get(long id)
        {
            Console.WriteLine($"Processing UserOrgLogic get ID={id}");

            UserOrg userorg = new UserOrg();
            userorg.id = id;

            DBPersist.get(userorg);

            return userorg;
        }

        public static void insert(UserOrg userorg)
        {
            Console.WriteLine($"Processing UserOrgLogic insert: {userorg}");

            userorg.is_active = 1;

            DBPersist.insert(userorg);
        }

        public static void update(long id, UserOrg userorg)
        {
            Console.WriteLine($"Processing UserOrgLogic update: ID = {id}\n{userorg}");

            userorg.id = id;
            DBPersist.update(userorg);
        }

        public static void delete(long id)
        {
            UserOrg userorg = get(id);
            userorg.is_active = 0;
            DBPersist.update(userorg);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using legr3;

namespace legr3
{


    public partial class UserOrgLogic : BaseLogic, IUserOrgLogic
    {


        public static IUserOrgLogic Create()
        {

            var userorg = new UserOrgLogic();
            var proxy = DispatchProxy.Create<IUserOrgLogic, Proxy<IUserOrgLogic>>();
            ((Proxy<IUserOrgLogic>)proxy).Target = userorg;
            ((Proxy<IUserOrgLogic>)proxy).BeforeAction = () => Console.WriteLine("Before method call");
            ((Proxy<IUserOrgLogic>)proxy).AfterAction = () => Console.WriteLine("After method call");

            //proxy.PerformAction();
            return proxy;
        }

        public  List<UserOrg> select()
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

        public  UserOrg get(long id)
        {
            Console.WriteLine($"Processing UserOrgLogic get ID={id}");

            UserOrg userorg = new UserOrg();
            userorg.id = id;

            DBPersist.get(userorg);

            return userorg;
        }

        public  void insert(UserOrg userorg)
        {
            Console.WriteLine($"Processing UserOrgLogic insert: {userorg}");

            userorg.is_active = 1;

            DBPersist.insert(userorg);
        }

        public  void update(long id, UserOrg userorg)
        {
            Console.WriteLine($"Processing UserOrgLogic update: ID = {id}\n{userorg}");

            userorg.id = id;
            DBPersist.update(userorg);
        }

        public  void delete(long id)
        {
            UserOrg userorg = get(id);
            userorg.is_active = 0;
            DBPersist.update(userorg);
        }
    }
}

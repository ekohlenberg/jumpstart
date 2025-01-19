
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using legr3;

namespace legr3
{


    public partial class UserActionGroupLogic : BaseLogic, IUserActionGroupLogic
    {


        public static IUserActionGroupLogic Create()
        {
            var useractiongroup = new UserActionGroupLogic();

            var proxy = DispatchProxy.Create<IUserActionGroupLogic, Proxy<IUserActionGroupLogic>>();
            ((Proxy<IUserActionGroupLogic>)proxy).Initialize();
            ((Proxy<IUserActionGroupLogic>)proxy).Target = useractiongroup;

            return proxy;
        }



        public  List<UserActionGroup> select()
        {
            Console.WriteLine("Processing UserActionGroupLogic select List");

            List<UserActionGroup> useractiongroups = new List<UserActionGroup>();

            void useractiongroupCallback(System.Data.Common.DbDataReader rdr)
            {
                UserActionGroup useractiongroup = new UserActionGroup();

                DBPersist.autoAssign(rdr, useractiongroup);

                useractiongroups.Add(useractiongroup);
            };

            DBPersist.select(useractiongroupCallback, $"select * from sec.user_action_group");

            return useractiongroups;
        }

        public  UserActionGroup get(long id)
        {
            Console.WriteLine($"Processing UserActionGroupLogic get ID={id}");

            UserActionGroup useractiongroup = new UserActionGroup();
            useractiongroup.id = id;

            DBPersist.get(useractiongroup);

            return useractiongroup;
        }

        public  void insert(UserActionGroup useractiongroup)
        {
            Console.WriteLine($"Processing UserActionGroupLogic insert: {useractiongroup}");

            useractiongroup.is_active = 1;

            DBPersist.insert(useractiongroup);
        }

        public  void update(long id, UserActionGroup useractiongroup)
        {
            Console.WriteLine($"Processing UserActionGroupLogic update: ID = {id}\n{useractiongroup}");

            useractiongroup.id = id;
            DBPersist.update(useractiongroup);
        }

        public  void delete(long id)
        {
            UserActionGroup useractiongroup = get(id);
            useractiongroup.is_active = 0;
            DBPersist.update(useractiongroup);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using legr3;

namespace legr3
{


    public partial class UserLogic : BaseLogic, IUserLogic
    {


        public static IUserLogic Create()
        {
            var user = new UserLogic();

            var proxy = DispatchProxy.Create<IUserLogic, Proxy<IUserLogic>>();
            ((Proxy<IUserLogic>)proxy).Initialize();
            ((Proxy<IUserLogic>)proxy).Target = user;

            return proxy;
        }



        public  List<User> select()
        {
            Console.WriteLine("Processing UserLogic select List");

            List<User> users = new List<User>();

            void userCallback(System.Data.Common.DbDataReader rdr)
            {
                User user = new User();

                DBPersist.autoAssign(rdr, user);

                users.Add(user);
            };

            DBPersist.select(userCallback, $"select * from sec.user");

            return users;
        }

        public  User get(long id)
        {
            Console.WriteLine($"Processing UserLogic get ID={id}");

            User user = new User();
            user.id = id;

            DBPersist.get(user);

            return user;
        }

        public  void insert(User user)
        {
            Console.WriteLine($"Processing UserLogic insert: {user}");

            user.is_active = 1;

            DBPersist.insert(user);
        }

        public  void update(long id, User user)
        {
            Console.WriteLine($"Processing UserLogic update: ID = {id}\n{user}");

            user.id = id;
            DBPersist.update(user);
        }

        public  void delete(long id)
        {
            User user = get(id);
            user.is_active = 0;
            DBPersist.update(user);
        }
    }
}

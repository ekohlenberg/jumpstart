
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class UserPasswordLogic : IUserPasswordLogic
    {


        public static IUserPasswordLogic Create()
        {
            var userpassword = new UserPasswordLogic();

            var proxy = DispatchProxy.Create<IUserPasswordLogic, Proxy<IUserPasswordLogic>>();
            ((Proxy<IUserPasswordLogic>)proxy).Initialize();
            ((Proxy<IUserPasswordLogic>)proxy).Target = userpassword;
            ((Proxy<IUserPasswordLogic>)proxy).DomainObj = "UserPassword";

            return proxy;
        }



        public  List<UserPassword> select()
        {
            Console.WriteLine("Processing UserPasswordLogic select List");

            List<UserPassword> userpasswords = new List<UserPassword>();

            void userpasswordCallback(System.Data.Common.DbDataReader rdr)
            {
                UserPassword userpassword = new UserPassword();

                DBPersist.autoAssign(rdr, userpassword);

                userpasswords.Add(userpassword);
            };

            DBPersist.select(userpasswordCallback, $"select * from sec.user_password");

            return userpasswords;
        }

        public  UserPassword get(long id)
        {
            Console.WriteLine($"Processing UserPasswordLogic get ID={id}");

            UserPassword userpassword = new UserPassword();
            userpassword.id = id;

            DBPersist.get(userpassword);

            return userpassword;
        }

        public  void insert(UserPassword userpassword)
        {
            Console.WriteLine($"Processing UserPasswordLogic insert: {userpassword}");

            userpassword.is_active = 1;

            DBPersist.insert(userpassword);
        }

        public  void update(long id, UserPassword userpassword)
        {
            Console.WriteLine($"Processing UserPasswordLogic update: ID = {id}\n{userpassword}");

            userpassword.id = id;
            DBPersist.update(userpassword);
        }

        public  void delete(long id)
        {
            UserPassword userpassword = get(id);
            userpassword.is_active = 0;
            DBPersist.update(userpassword);
        }
    }
}

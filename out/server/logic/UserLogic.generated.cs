using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;


namespace legr
{
    public partial class UserLogic : Logic
    {
    
        public static List<User> select()
        {
            Console.WriteLine("Processing UserLogic select List" );

            List<User> users = [];

            void userCallback(System.Data.Common.DbDataReader rdr) 
            {
                User user = [];

                DBPersist.autoAssign(rdr, user);

                users.Add(user);
            };

            DBPersist.select(userCallback, "select * from sec.user");

            return users;
        }

        
        public static User get(long id)
        {
            Console.WriteLine("Processing UserLogic get ID=" + id.ToString());

            User user = [];
            user.id = id;

            DBPersist.get(user);

            return user;
        }

        
        public static void insert( User user)
        {
            Console.WriteLine("Processing UserLogic insert: " + user.ToString()  );

            user.is_active = "Y";

            DBPersist.insert(user);
        }

       
        public static void update(long id,  User user)
        {
            Console.WriteLine("Processing UserLogic update: ID = " + id.ToString() + "\n" + user.ToString()  );

            user.id = id;
            DBPersist.update(user);
        }

        
        public static void delete(long id)
        {
            User user = get(id);
            user.is_active = "N";
             DBPersist.update(user);
        }
    }
}

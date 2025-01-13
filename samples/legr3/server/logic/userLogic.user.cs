
using System;


namespace legr3
{
    public interface IUserLogic
    {
        List<User> select();
        User get(long id);
        void insert(User user);
        void update(long id, User user);
        void delete( long id );
    }


    public partial class UserLogic
    {
        public UserLogic()
        {
           
        }
        
    }
}



using System;


namespace defarge
{
    public interface IUserLogic
    {  
        // Generated methods
        List<User> select();
        User get(long id);
        void insert(User user);
        void update(long id, User user);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class UserLogic
    {
        public UserLogic()
        {
           
        }
        
    }
}


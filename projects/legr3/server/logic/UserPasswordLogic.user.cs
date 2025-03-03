
using System;


namespace legr3
{
    public interface IUserPasswordLogic
    {  
        // Generated methods
        List<UserPassword> select();
        UserPassword get(long id);
        void insert(UserPassword userpassword);
        void update(long id, UserPassword userpassword);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class UserPasswordLogic
    {
        public UserPasswordLogic()
        {
           
        }
        
    }
}


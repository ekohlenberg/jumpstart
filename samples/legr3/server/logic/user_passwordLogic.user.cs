
using System;


namespace legr3
{
    public interface IUserPasswordLogic
    {
        List<UserPassword> select();
        UserPassword get(long id);
        void insert(UserPassword userpassword);
        void update(long id, UserPassword userpassword);
        void delete( long id );
    }


    public partial class UserPasswordLogic
    {
        public UserPasswordLogic()
        {
           
        }
        
    }
}


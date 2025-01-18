
using System;


namespace 
{
    public interface IUserActionGroupLogic
    {
        List<UserActionGroup> select();
        UserActionGroup get(long id);
        void insert(UserActionGroup useractiongroup);
        void update(long id, UserActionGroup useractiongroup);
        void delete( long id );
    }


    public partial class UserActionGroupLogic
    {
        public UserActionGroupLogic()
        {
           
        }
        
    }
}


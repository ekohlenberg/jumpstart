
using System;


namespace legr3
{
    public interface IUserOrgLogic
    {
        List<UserOrg> select();
        UserOrg get(long id);
        void insert(UserOrg userorg);
        void update(long id, UserOrg userorg);
        void delete( long id );
    }


    public partial class UserOrgLogic
    {
        public UserOrgLogic()
        {
           
        }
        
    }
}


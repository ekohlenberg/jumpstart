
using System;


namespace defarge
{
    public interface IUserOrgLogic
    {  
        // Generated methods
        List<UserOrg> select();
        UserOrg get(long id);
        void insert(UserOrg userorg);
        void update(long id, UserOrg userorg);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class UserOrgLogic
    {
        public UserOrgLogic()
        {
           
        }
        
    }
}


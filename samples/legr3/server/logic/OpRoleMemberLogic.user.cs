
using System;


namespace legr3
{
    public interface IOpRoleMemberLogic
    {  
        // Generated methods
        List<OpRoleMember> select();
        OpRoleMember get(long id);
        void insert(OpRoleMember oprolemember);
        void update(long id, OpRoleMember oprolemember);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class OpRoleMemberLogic
    {
        public OpRoleMemberLogic()
        {
           
        }
        
    }
}


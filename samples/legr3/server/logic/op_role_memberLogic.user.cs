
using System;


namespace legr3
{
    public interface IOpRoleMemberLogic
    {
        List<OpRoleMember> select();
        OpRoleMember get(long id);
        void insert(OpRoleMember oprolemember);
        void update(long id, OpRoleMember oprolemember);
        void delete( long id );
    }


    public partial class OpRoleMemberLogic
    {
        public OpRoleMemberLogic()
        {
           
        }
        
    }
}


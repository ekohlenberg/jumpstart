
using System;


namespace legr3
{
    public interface IOpRoleMapLogic
    {
        List<OpRoleMap> select();
        OpRoleMap get(long id);
        void insert(OpRoleMap oprolemap);
        void update(long id, OpRoleMap oprolemap);
        void delete( long id );
    }


    public partial class OpRoleMapLogic
    {
        public OpRoleMapLogic()
        {
           
        }
        
    }
}


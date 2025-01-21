
using System;


namespace legr3
{
    public interface IOpRoleLogic
    {
        List<OpRole> select();
        OpRole get(long id);
        void insert(OpRole oprole);
        void update(long id, OpRole oprole);
        void delete( long id );
    }


    public partial class OpRoleLogic
    {
        public OpRoleLogic()
        {
           
        }
        
    }
}


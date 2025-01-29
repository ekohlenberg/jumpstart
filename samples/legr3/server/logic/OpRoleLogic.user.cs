
using System;


namespace legr3
{
    public interface IOpRoleLogic
    {  
        // Generated methods
        List<OpRole> select();
        OpRole get(long id);
        void insert(OpRole oprole);
        void update(long id, OpRole oprole);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class OpRoleLogic
    {
        public OpRoleLogic()
        {
           
        }
        
    }
}


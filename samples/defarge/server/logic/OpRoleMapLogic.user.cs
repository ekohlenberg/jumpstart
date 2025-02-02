
using System;


namespace defarge
{
    public interface IOpRoleMapLogic
    {  
        // Generated methods
        List<OpRoleMap> select();
        OpRoleMap get(long id);
        void insert(OpRoleMap oprolemap);
        void update(long id, OpRoleMap oprolemap);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class OpRoleMapLogic
    {
        public OpRoleMapLogic()
        {
           
        }
        
    }
}


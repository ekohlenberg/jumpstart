
using System;


namespace defarge
{
    public interface IOperationLogic
    {  
        // Generated methods
        List<Operation> select();
        Operation get(long id);
        void insert(Operation operation);
        void update(long id, Operation operation);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class OperationLogic
    {
        public OperationLogic()
        {
           
        }
        
    }
}



using System;


namespace legr3
{
    public interface IOperationLogic
    {
        List<Operation> select();
        Operation get(long id);
        void insert(Operation operation);
        void update(long id, Operation operation);
        void delete( long id );
    }


    public partial class OperationLogic
    {
        public OperationLogic()
        {
           
        }
        
    }
}



using System;


namespace defarge
{
    public interface IExecutionLogic
    {  
        // Generated methods
        List<Execution> select();
        Execution get(long id);
        void insert(Execution execution);
        void update(long id, Execution execution);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ExecutionLogic
    {
        public ExecutionLogic()
        {
           
        }
        
    }
}


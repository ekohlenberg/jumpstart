
using System;


namespace defarge
{
    public interface IProcessLogic
    {  
        // Generated methods
        List<Process> select();
        Process get(long id);
        void insert(Process process);
        void update(long id, Process process);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ProcessLogic
    {
        public ProcessLogic()
        {
           
        }
        
    }
}


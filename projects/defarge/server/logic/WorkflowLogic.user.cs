
using System;


namespace defarge
{
    public interface IWorkflowLogic
    {  
        // Generated methods
        List<Workflow> select();
        Workflow get(long id);
        void insert(Workflow workflow);
        void update(long id, Workflow workflow);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class WorkflowLogic
    {
        public WorkflowLogic()
        {
           
        }
        
    }
}



using System;


namespace defarge
{
    public interface IWorkflowProcessLogic
    {  
        // Generated methods
        List<WorkflowProcess> select();
        WorkflowProcess get(long id);
        void insert(WorkflowProcess workflowprocess);
        void update(long id, WorkflowProcess workflowprocess);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class WorkflowProcessLogic
    {
        public WorkflowProcessLogic()
        {
           
        }
        
    }
}


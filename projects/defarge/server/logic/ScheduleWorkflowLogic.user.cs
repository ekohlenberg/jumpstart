
using System;


namespace defarge
{
    public interface IScheduleWorkflowLogic
    {  
        // Generated methods
        List<ScheduleWorkflow> select();
        ScheduleWorkflow get(long id);
        void insert(ScheduleWorkflow scheduleworkflow);
        void update(long id, ScheduleWorkflow scheduleworkflow);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ScheduleWorkflowLogic
    {
        public ScheduleWorkflowLogic()
        {
           
        }
        
    }
}


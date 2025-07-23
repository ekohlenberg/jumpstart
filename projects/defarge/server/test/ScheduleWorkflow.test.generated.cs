using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ScheduleWorkflowTest : BaseTest
    {
        public static void testInsert()
        {
            var scheduleworkflow = new ScheduleWorkflow();


                    scheduleworkflow.schedule_id = BaseTest.getLastId("schedule");
                    
                    scheduleworkflow.workflow_id = BaseTest.getLastId("workflow");
                    
                Console.WriteLine("Testing ScheduleWorkflowLogic insert: " + scheduleworkflow.ToString());
                ScheduleWorkflowLogic.Create().insert(scheduleworkflow);
                BaseTest.addLastId("schedule_workflow", scheduleworkflow.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("ScheduleWorkflow");
            var scheduleworkflow = ScheduleWorkflowLogic.Create().get(lastId);


                            scheduleworkflow.schedule_id = BaseTest.getLastId("schedule");
                        
                            scheduleworkflow.workflow_id = BaseTest.getLastId("workflow");
                        
                Console.WriteLine("Testing ScheduleWorkflowLogic update: " + scheduleworkflow.ToString());
                ScheduleWorkflowLogic.Create().update(lastId, scheduleworkflow);
                    }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class WorkflowProcessTest : BaseTest
    {
        public static void testInsert()
        {
            var workflowprocess = new WorkflowProcess();


                    workflowprocess.workflow_id = BaseTest.getLastId("workflow");
                    
                    workflowprocess.process_id = BaseTest.getLastId("process");
                    
                    workflowprocess.execution_sequence = Convert.ToInt32(BaseTest.getTestData(workflowprocess, "INTEGER", TestDataType.random));
                    
                    workflowprocess.server_id = BaseTest.getLastId("server");
                    
                Console.WriteLine("Testing WorkflowProcessLogic insert: " + workflowprocess.ToString());
                WorkflowProcessLogic.Create().insert(workflowprocess);
                BaseTest.addLastId("workflow_process", workflowprocess.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("WorkflowProcess");
            var workflowprocess = WorkflowProcessLogic.Create().get(lastId);


                            workflowprocess.workflow_id = BaseTest.getLastId("workflow");
                        
                            workflowprocess.process_id = BaseTest.getLastId("process");
                        
                        workflowprocess.execution_sequence = (int) BaseTest.getTestData(workflowprocess, "INTEGER", TestDataType.random);
                    
                            workflowprocess.server_id = BaseTest.getLastId("server");
                        
                Console.WriteLine("Testing WorkflowProcessLogic update: " + workflowprocess.ToString());
                WorkflowProcessLogic.Create().update(lastId, workflowprocess);
                    }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class WorkflowTest : BaseTest
    {
        public static void testInsert()
        {
            var workflow = new Workflow();


                    workflow.parent_workflow_id = BaseTest.getLastId("workflow");
                    
                    workflow.name = Convert.ToString(BaseTest.getTestData(workflow, "VARCHAR", TestDataType.random));
                    
                    workflow.description = Convert.ToString(BaseTest.getTestData(workflow, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing WorkflowLogic insert: " + workflow.ToString());
                WorkflowLogic.Create().insert(workflow);
                BaseTest.addLastId("workflow", workflow.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Workflow");
            var workflow = WorkflowLogic.Create().get(lastId);


                            workflow.parent_workflow_id = BaseTest.getLastId("workflow");
                        
                        workflow.name = (string) BaseTest.getTestData(workflow, "VARCHAR", TestDataType.random);
                    
                        workflow.description = (string) BaseTest.getTestData(workflow, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing WorkflowLogic update: " + workflow.ToString());
                WorkflowLogic.Create().update(lastId, workflow);
                    }
    }
}

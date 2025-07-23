
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class WorkflowProcessLogic : IWorkflowProcessLogic
    {


        public static IWorkflowProcessLogic Create()
        {
            var workflowprocess = new WorkflowProcessLogic();

            var proxy = DispatchProxy.Create<IWorkflowProcessLogic, Proxy<IWorkflowProcessLogic>>();
            ((Proxy<IWorkflowProcessLogic>)proxy).Initialize();
            ((Proxy<IWorkflowProcessLogic>)proxy).Target = workflowprocess;
            ((Proxy<IWorkflowProcessLogic>)proxy).DomainObj = "WorkflowProcess";

            return proxy;
        }



        public  List<WorkflowProcess> select()
        {
            Console.WriteLine("Processing WorkflowProcessLogic select List");

            List<WorkflowProcess> workflowprocesss = new List<WorkflowProcess>();

            void workflowprocessCallback(System.Data.Common.DbDataReader rdr)
            {
                WorkflowProcess workflowprocess = new WorkflowProcess();

                DBPersist.autoAssign(rdr, workflowprocess);

                workflowprocesss.Add(workflowprocess);
            };

            DBPersist.select(workflowprocessCallback, $"select * from core.workflow_process");

            return workflowprocesss;
        }

        public  WorkflowProcess get(long id)
        {
            Console.WriteLine($"Processing WorkflowProcessLogic get ID={id}");

            WorkflowProcess workflowprocess = new WorkflowProcess();
            workflowprocess.id = id;

            DBPersist.get(workflowprocess);

            return workflowprocess;
        }

        public  void insert(WorkflowProcess workflowprocess)
        {
            Console.WriteLine($"Processing WorkflowProcessLogic insert: {workflowprocess}");

            workflowprocess.is_active = 1;

            DBPersist.insert(workflowprocess);
        }

        public  void update(long id, WorkflowProcess workflowprocess)
        {
            Console.WriteLine($"Processing WorkflowProcessLogic update: ID = {id}\n{workflowprocess}");

            workflowprocess.id = id;
            DBPersist.update(workflowprocess);
        }

        public  void delete(long id)
        {
            WorkflowProcess workflowprocess = get(id);
            workflowprocess.is_active = 0;
            DBPersist.update(workflowprocess);
        }
    }
}

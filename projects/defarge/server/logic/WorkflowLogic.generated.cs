
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class WorkflowLogic : IWorkflowLogic
    {


        public static IWorkflowLogic Create()
        {
            var workflow = new WorkflowLogic();

            var proxy = DispatchProxy.Create<IWorkflowLogic, Proxy<IWorkflowLogic>>();
            ((Proxy<IWorkflowLogic>)proxy).Initialize();
            ((Proxy<IWorkflowLogic>)proxy).Target = workflow;
            ((Proxy<IWorkflowLogic>)proxy).DomainObj = "Workflow";

            return proxy;
        }



        public  List<Workflow> select()
        {
            Console.WriteLine("Processing WorkflowLogic select List");

            List<Workflow> workflows = new List<Workflow>();

            void workflowCallback(System.Data.Common.DbDataReader rdr)
            {
                Workflow workflow = new Workflow();

                DBPersist.autoAssign(rdr, workflow);

                workflows.Add(workflow);
            };

            DBPersist.select(workflowCallback, $"select * from core.workflow");

            return workflows;
        }

        public  Workflow get(long id)
        {
            Console.WriteLine($"Processing WorkflowLogic get ID={id}");

            Workflow workflow = new Workflow();
            workflow.id = id;

            DBPersist.get(workflow);

            return workflow;
        }

        public  void insert(Workflow workflow)
        {
            Console.WriteLine($"Processing WorkflowLogic insert: {workflow}");

            workflow.is_active = 1;

            DBPersist.insert(workflow);
        }

        public  void update(long id, Workflow workflow)
        {
            Console.WriteLine($"Processing WorkflowLogic update: ID = {id}\n{workflow}");

            workflow.id = id;
            DBPersist.update(workflow);
        }

        public  void delete(long id)
        {
            Workflow workflow = get(id);
            workflow.is_active = 0;
            DBPersist.update(workflow);
        }
    }
}

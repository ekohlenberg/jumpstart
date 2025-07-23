
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ScheduleWorkflowLogic : IScheduleWorkflowLogic
    {


        public static IScheduleWorkflowLogic Create()
        {
            var scheduleworkflow = new ScheduleWorkflowLogic();

            var proxy = DispatchProxy.Create<IScheduleWorkflowLogic, Proxy<IScheduleWorkflowLogic>>();
            ((Proxy<IScheduleWorkflowLogic>)proxy).Initialize();
            ((Proxy<IScheduleWorkflowLogic>)proxy).Target = scheduleworkflow;
            ((Proxy<IScheduleWorkflowLogic>)proxy).DomainObj = "ScheduleWorkflow";

            return proxy;
        }



        public  List<ScheduleWorkflow> select()
        {
            Console.WriteLine("Processing ScheduleWorkflowLogic select List");

            List<ScheduleWorkflow> scheduleworkflows = new List<ScheduleWorkflow>();

            void scheduleworkflowCallback(System.Data.Common.DbDataReader rdr)
            {
                ScheduleWorkflow scheduleworkflow = new ScheduleWorkflow();

                DBPersist.autoAssign(rdr, scheduleworkflow);

                scheduleworkflows.Add(scheduleworkflow);
            };

            DBPersist.select(scheduleworkflowCallback, $"select * from core.schedule_workflow");

            return scheduleworkflows;
        }

        public  ScheduleWorkflow get(long id)
        {
            Console.WriteLine($"Processing ScheduleWorkflowLogic get ID={id}");

            ScheduleWorkflow scheduleworkflow = new ScheduleWorkflow();
            scheduleworkflow.id = id;

            DBPersist.get(scheduleworkflow);

            return scheduleworkflow;
        }

        public  void insert(ScheduleWorkflow scheduleworkflow)
        {
            Console.WriteLine($"Processing ScheduleWorkflowLogic insert: {scheduleworkflow}");

            scheduleworkflow.is_active = 1;

            DBPersist.insert(scheduleworkflow);
        }

        public  void update(long id, ScheduleWorkflow scheduleworkflow)
        {
            Console.WriteLine($"Processing ScheduleWorkflowLogic update: ID = {id}\n{scheduleworkflow}");

            scheduleworkflow.id = id;
            DBPersist.update(scheduleworkflow);
        }

        public  void delete(long id)
        {
            ScheduleWorkflow scheduleworkflow = get(id);
            scheduleworkflow.is_active = 0;
            DBPersist.update(scheduleworkflow);
        }
    }
}

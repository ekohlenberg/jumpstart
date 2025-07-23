
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ExecutionLogic : IExecutionLogic
    {


        public static IExecutionLogic Create()
        {
            var execution = new ExecutionLogic();

            var proxy = DispatchProxy.Create<IExecutionLogic, Proxy<IExecutionLogic>>();
            ((Proxy<IExecutionLogic>)proxy).Initialize();
            ((Proxy<IExecutionLogic>)proxy).Target = execution;
            ((Proxy<IExecutionLogic>)proxy).DomainObj = "Execution";

            return proxy;
        }



        public  List<Execution> select()
        {
            Console.WriteLine("Processing ExecutionLogic select List");

            List<Execution> executions = new List<Execution>();

            void executionCallback(System.Data.Common.DbDataReader rdr)
            {
                Execution execution = new Execution();

                DBPersist.autoAssign(rdr, execution);

                executions.Add(execution);
            };

            DBPersist.select(executionCallback, $"select * from core.execution");

            return executions;
        }

        public  Execution get(long id)
        {
            Console.WriteLine($"Processing ExecutionLogic get ID={id}");

            Execution execution = new Execution();
            execution.id = id;

            DBPersist.get(execution);

            return execution;
        }

        public  void insert(Execution execution)
        {
            Console.WriteLine($"Processing ExecutionLogic insert: {execution}");

            execution.is_active = 1;

            DBPersist.insert(execution);
        }

        public  void update(long id, Execution execution)
        {
            Console.WriteLine($"Processing ExecutionLogic update: ID = {id}\n{execution}");

            execution.id = id;
            DBPersist.update(execution);
        }

        public  void delete(long id)
        {
            Execution execution = get(id);
            execution.is_active = 0;
            DBPersist.update(execution);
        }
    }
}

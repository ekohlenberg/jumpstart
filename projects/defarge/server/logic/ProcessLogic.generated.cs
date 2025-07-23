
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ProcessLogic : IProcessLogic
    {


        public static IProcessLogic Create()
        {
            var process = new ProcessLogic();

            var proxy = DispatchProxy.Create<IProcessLogic, Proxy<IProcessLogic>>();
            ((Proxy<IProcessLogic>)proxy).Initialize();
            ((Proxy<IProcessLogic>)proxy).Target = process;
            ((Proxy<IProcessLogic>)proxy).DomainObj = "Process";

            return proxy;
        }



        public  List<Process> select()
        {
            Console.WriteLine("Processing ProcessLogic select List");

            List<Process> processs = new List<Process>();

            void processCallback(System.Data.Common.DbDataReader rdr)
            {
                Process process = new Process();

                DBPersist.autoAssign(rdr, process);

                processs.Add(process);
            };

            DBPersist.select(processCallback, $"select * from core.process");

            return processs;
        }

        public  Process get(long id)
        {
            Console.WriteLine($"Processing ProcessLogic get ID={id}");

            Process process = new Process();
            process.id = id;

            DBPersist.get(process);

            return process;
        }

        public  void insert(Process process)
        {
            Console.WriteLine($"Processing ProcessLogic insert: {process}");

            process.is_active = 1;

            DBPersist.insert(process);
        }

        public  void update(long id, Process process)
        {
            Console.WriteLine($"Processing ProcessLogic update: ID = {id}\n{process}");

            process.id = id;
            DBPersist.update(process);
        }

        public  void delete(long id)
        {
            Process process = get(id);
            process.is_active = 0;
            DBPersist.update(process);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using legr3;

namespace legr3
{


    public partial class OperationLogic : IOperationLogic
    {


        public static IOperationLogic Create()
        {
            var operation = new OperationLogic();

            var proxy = DispatchProxy.Create<IOperationLogic, Proxy<IOperationLogic>>();
            ((Proxy<IOperationLogic>)proxy).Initialize();
            ((Proxy<IOperationLogic>)proxy).Target = operation;
            ((Proxy<IOperationLogic>)proxy).DomainObj = "Operation";

            return proxy;
        }



        public  List<Operation> select()
        {
            Console.WriteLine("Processing OperationLogic select List");

            List<Operation> operations = new List<Operation>();

            void operationCallback(System.Data.Common.DbDataReader rdr)
            {
                Operation operation = new Operation();

                DBPersist.autoAssign(rdr, operation);

                operations.Add(operation);
            };

            DBPersist.select(operationCallback, $"select * from sec.operation");

            return operations;
        }

        public  Operation get(long id)
        {
            Console.WriteLine($"Processing OperationLogic get ID={id}");

            Operation operation = new Operation();
            operation.id = id;

            DBPersist.get(operation);

            return operation;
        }

        public  void insert(Operation operation)
        {
            Console.WriteLine($"Processing OperationLogic insert: {operation}");

            operation.is_active = 1;

            DBPersist.insert(operation);
        }

        public  void update(long id, Operation operation)
        {
            Console.WriteLine($"Processing OperationLogic update: ID = {id}\n{operation}");

            operation.id = id;
            DBPersist.update(operation);
        }

        public  void delete(long id)
        {
            Operation operation = get(id);
            operation.is_active = 0;
            DBPersist.update(operation);
        }
    }
}

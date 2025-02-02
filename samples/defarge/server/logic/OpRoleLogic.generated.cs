
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class OpRoleLogic : IOpRoleLogic
    {


        public static IOpRoleLogic Create()
        {
            var oprole = new OpRoleLogic();

            var proxy = DispatchProxy.Create<IOpRoleLogic, Proxy<IOpRoleLogic>>();
            ((Proxy<IOpRoleLogic>)proxy).Initialize();
            ((Proxy<IOpRoleLogic>)proxy).Target = oprole;
            ((Proxy<IOpRoleLogic>)proxy).DomainObj = "OpRole";

            return proxy;
        }



        public  List<OpRole> select()
        {
            Console.WriteLine("Processing OpRoleLogic select List");

            List<OpRole> oproles = new List<OpRole>();

            void oproleCallback(System.Data.Common.DbDataReader rdr)
            {
                OpRole oprole = new OpRole();

                DBPersist.autoAssign(rdr, oprole);

                oproles.Add(oprole);
            };

            DBPersist.select(oproleCallback, $"select * from sec.op_role");

            return oproles;
        }

        public  OpRole get(long id)
        {
            Console.WriteLine($"Processing OpRoleLogic get ID={id}");

            OpRole oprole = new OpRole();
            oprole.id = id;

            DBPersist.get(oprole);

            return oprole;
        }

        public  void insert(OpRole oprole)
        {
            Console.WriteLine($"Processing OpRoleLogic insert: {oprole}");

            oprole.is_active = 1;

            DBPersist.insert(oprole);
        }

        public  void update(long id, OpRole oprole)
        {
            Console.WriteLine($"Processing OpRoleLogic update: ID = {id}\n{oprole}");

            oprole.id = id;
            DBPersist.update(oprole);
        }

        public  void delete(long id)
        {
            OpRole oprole = get(id);
            oprole.is_active = 0;
            DBPersist.update(oprole);
        }
    }
}

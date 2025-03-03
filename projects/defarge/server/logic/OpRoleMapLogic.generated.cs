
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class OpRoleMapLogic : IOpRoleMapLogic
    {


        public static IOpRoleMapLogic Create()
        {
            var oprolemap = new OpRoleMapLogic();

            var proxy = DispatchProxy.Create<IOpRoleMapLogic, Proxy<IOpRoleMapLogic>>();
            ((Proxy<IOpRoleMapLogic>)proxy).Initialize();
            ((Proxy<IOpRoleMapLogic>)proxy).Target = oprolemap;
            ((Proxy<IOpRoleMapLogic>)proxy).DomainObj = "OpRoleMap";

            return proxy;
        }



        public  List<OpRoleMap> select()
        {
            Console.WriteLine("Processing OpRoleMapLogic select List");

            List<OpRoleMap> oprolemaps = new List<OpRoleMap>();

            void oprolemapCallback(System.Data.Common.DbDataReader rdr)
            {
                OpRoleMap oprolemap = new OpRoleMap();

                DBPersist.autoAssign(rdr, oprolemap);

                oprolemaps.Add(oprolemap);
            };

            DBPersist.select(oprolemapCallback, $"select * from sec.op_role_map");

            return oprolemaps;
        }

        public  OpRoleMap get(long id)
        {
            Console.WriteLine($"Processing OpRoleMapLogic get ID={id}");

            OpRoleMap oprolemap = new OpRoleMap();
            oprolemap.id = id;

            DBPersist.get(oprolemap);

            return oprolemap;
        }

        public  void insert(OpRoleMap oprolemap)
        {
            Console.WriteLine($"Processing OpRoleMapLogic insert: {oprolemap}");

            oprolemap.is_active = 1;

            DBPersist.insert(oprolemap);
        }

        public  void update(long id, OpRoleMap oprolemap)
        {
            Console.WriteLine($"Processing OpRoleMapLogic update: ID = {id}\n{oprolemap}");

            oprolemap.id = id;
            DBPersist.update(oprolemap);
        }

        public  void delete(long id)
        {
            OpRoleMap oprolemap = get(id);
            oprolemap.is_active = 0;
            DBPersist.update(oprolemap);
        }
    }
}

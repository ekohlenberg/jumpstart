
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using legr3;

namespace legr3
{


    public partial class OpRoleMemberLogic : BaseLogic, IOpRoleMemberLogic
    {


        public static IOpRoleMemberLogic Create()
        {
            var oprolemember = new OpRoleMemberLogic();

            var proxy = DispatchProxy.Create<IOpRoleMemberLogic, Proxy<IOpRoleMemberLogic>>();
            ((Proxy<IOpRoleMemberLogic>)proxy).Initialize();
            ((Proxy<IOpRoleMemberLogic>)proxy).Target = oprolemember;

            return proxy;
        }



        public  List<OpRoleMember> select()
        {
            Console.WriteLine("Processing OpRoleMemberLogic select List");

            List<OpRoleMember> oprolemembers = new List<OpRoleMember>();

            void oprolememberCallback(System.Data.Common.DbDataReader rdr)
            {
                OpRoleMember oprolemember = new OpRoleMember();

                DBPersist.autoAssign(rdr, oprolemember);

                oprolemembers.Add(oprolemember);
            };

            DBPersist.select(oprolememberCallback, $"select * from sec.op_role_member");

            return oprolemembers;
        }

        public  OpRoleMember get(long id)
        {
            Console.WriteLine($"Processing OpRoleMemberLogic get ID={id}");

            OpRoleMember oprolemember = new OpRoleMember();
            oprolemember.id = id;

            DBPersist.get(oprolemember);

            return oprolemember;
        }

        public  void insert(OpRoleMember oprolemember)
        {
            Console.WriteLine($"Processing OpRoleMemberLogic insert: {oprolemember}");

            oprolemember.is_active = 1;

            DBPersist.insert(oprolemember);
        }

        public  void update(long id, OpRoleMember oprolemember)
        {
            Console.WriteLine($"Processing OpRoleMemberLogic update: ID = {id}\n{oprolemember}");

            oprolemember.id = id;
            DBPersist.update(oprolemember);
        }

        public  void delete(long id)
        {
            OpRoleMember oprolemember = get(id);
            oprolemember.is_active = 0;
            DBPersist.update(oprolemember);
        }
    }
}

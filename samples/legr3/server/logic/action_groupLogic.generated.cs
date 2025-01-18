
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using ;

namespace 
{


    public partial class ActionGroupLogic : BaseLogic, IActionGroupLogic
    {


        public static IActionGroupLogic Create()
        {
            var actiongroup = new ActionGroupLogic();

            var proxy = DispatchProxy.Create<IActionGroupLogic, Proxy<IActionGroupLogic>>();
            ((Proxy<IActionGroupLogic>)proxy).Initialize();
            ((Proxy<IActionGroupLogic>)proxy).Target = actiongroup;

            return proxy;
        }



        public  List<ActionGroup> select()
        {
            Console.WriteLine("Processing ActionGroupLogic select List");

            List<ActionGroup> actiongroups = new List<ActionGroup>();

            void actiongroupCallback(System.Data.Common.DbDataReader rdr)
            {
                ActionGroup actiongroup = new ActionGroup();

                DBPersist.autoAssign(rdr, actiongroup);

                actiongroups.Add(actiongroup);
            };

            DBPersist.select(actiongroupCallback, $"select * from sec.action_group");

            return actiongroups;
        }

        public  ActionGroup get(long id)
        {
            Console.WriteLine($"Processing ActionGroupLogic get ID={id}");

            ActionGroup actiongroup = new ActionGroup();
            actiongroup.id = id;

            DBPersist.get(actiongroup);

            return actiongroup;
        }

        public  void insert(ActionGroup actiongroup)
        {
            Console.WriteLine($"Processing ActionGroupLogic insert: {actiongroup}");

            actiongroup.is_active = 1;

            DBPersist.insert(actiongroup);
        }

        public  void update(long id, ActionGroup actiongroup)
        {
            Console.WriteLine($"Processing ActionGroupLogic update: ID = {id}\n{actiongroup}");

            actiongroup.id = id;
            DBPersist.update(actiongroup);
        }

        public  void delete(long id)
        {
            ActionGroup actiongroup = get(id);
            actiongroup.is_active = 0;
            DBPersist.update(actiongroup);
        }
    }
}

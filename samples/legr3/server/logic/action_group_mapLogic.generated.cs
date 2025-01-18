
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using ;

namespace 
{


    public partial class ActionGroupMapLogic : BaseLogic, IActionGroupMapLogic
    {


        public static IActionGroupMapLogic Create()
        {
            var actiongroupmap = new ActionGroupMapLogic();

            var proxy = DispatchProxy.Create<IActionGroupMapLogic, Proxy<IActionGroupMapLogic>>();
            ((Proxy<IActionGroupMapLogic>)proxy).Initialize();
            ((Proxy<IActionGroupMapLogic>)proxy).Target = actiongroupmap;

            return proxy;
        }



        public  List<ActionGroupMap> select()
        {
            Console.WriteLine("Processing ActionGroupMapLogic select List");

            List<ActionGroupMap> actiongroupmaps = new List<ActionGroupMap>();

            void actiongroupmapCallback(System.Data.Common.DbDataReader rdr)
            {
                ActionGroupMap actiongroupmap = new ActionGroupMap();

                DBPersist.autoAssign(rdr, actiongroupmap);

                actiongroupmaps.Add(actiongroupmap);
            };

            DBPersist.select(actiongroupmapCallback, $"select * from sec.action_group_map");

            return actiongroupmaps;
        }

        public  ActionGroupMap get(long id)
        {
            Console.WriteLine($"Processing ActionGroupMapLogic get ID={id}");

            ActionGroupMap actiongroupmap = new ActionGroupMap();
            actiongroupmap.id = id;

            DBPersist.get(actiongroupmap);

            return actiongroupmap;
        }

        public  void insert(ActionGroupMap actiongroupmap)
        {
            Console.WriteLine($"Processing ActionGroupMapLogic insert: {actiongroupmap}");

            actiongroupmap.is_active = 1;

            DBPersist.insert(actiongroupmap);
        }

        public  void update(long id, ActionGroupMap actiongroupmap)
        {
            Console.WriteLine($"Processing ActionGroupMapLogic update: ID = {id}\n{actiongroupmap}");

            actiongroupmap.id = id;
            DBPersist.update(actiongroupmap);
        }

        public  void delete(long id)
        {
            ActionGroupMap actiongroupmap = get(id);
            actiongroupmap.is_active = 0;
            DBPersist.update(actiongroupmap);
        }
    }
}

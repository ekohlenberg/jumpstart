
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using legr3;

namespace legr3
{


    public partial class ActionLogic : BaseLogic, IActionLogic
    {


        public static IActionLogic Create()
        {
            var action = new ActionLogic();

            var proxy = DispatchProxy.Create<IActionLogic, Proxy<IActionLogic>>();
            ((Proxy<IActionLogic>)proxy).Initialize();
            ((Proxy<IActionLogic>)proxy).Target = action;

            return proxy;
        }



        public  List<Action> select()
        {
            Console.WriteLine("Processing ActionLogic select List");

            List<Action> actions = new List<Action>();

            void actionCallback(System.Data.Common.DbDataReader rdr)
            {
                Action action = new Action();

                DBPersist.autoAssign(rdr, action);

                actions.Add(action);
            };

            DBPersist.select(actionCallback, $"select * from sec.action");

            return actions;
        }

        public  Action get(long id)
        {
            Console.WriteLine($"Processing ActionLogic get ID={id}");

            Action action = new Action();
            action.id = id;

            DBPersist.get(action);

            return action;
        }

        public  void insert(Action action)
        {
            Console.WriteLine($"Processing ActionLogic insert: {action}");

            action.is_active = 1;

            DBPersist.insert(action);
        }

        public  void update(long id, Action action)
        {
            Console.WriteLine($"Processing ActionLogic update: ID = {id}\n{action}");

            action.id = id;
            DBPersist.update(action);
        }

        public  void delete(long id)
        {
            Action action = get(id);
            action.is_active = 0;
            DBPersist.update(action);
        }
    }
}

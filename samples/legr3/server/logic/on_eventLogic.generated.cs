
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using legr3;

namespace legr3
{


    public partial class OnEventLogic : BaseLogic, IOnEventLogic
    {


        public static IOnEventLogic Create()
        {
            var onevent = new OnEventLogic();

            var proxy = DispatchProxy.Create<IOnEventLogic, Proxy<IOnEventLogic>>();
            ((Proxy<IOnEventLogic>)proxy).Initialize();
            ((Proxy<IOnEventLogic>)proxy).Target = onevent;

            return proxy;
        }



        public  List<OnEvent> select()
        {
            Console.WriteLine("Processing OnEventLogic select List");

            List<OnEvent> onevents = new List<OnEvent>();

            void oneventCallback(System.Data.Common.DbDataReader rdr)
            {
                OnEvent onevent = new OnEvent();

                DBPersist.autoAssign(rdr, onevent);

                onevents.Add(onevent);
            };

            DBPersist.select(oneventCallback, $"select * from core.on_event");

            return onevents;
        }

        public  OnEvent get(long id)
        {
            Console.WriteLine($"Processing OnEventLogic get ID={id}");

            OnEvent onevent = new OnEvent();
            onevent.id = id;

            DBPersist.get(onevent);

            return onevent;
        }

        public  void insert(OnEvent onevent)
        {
            Console.WriteLine($"Processing OnEventLogic insert: {onevent}");

            onevent.is_active = 1;

            DBPersist.insert(onevent);
        }

        public  void update(long id, OnEvent onevent)
        {
            Console.WriteLine($"Processing OnEventLogic update: ID = {id}\n{onevent}");

            onevent.id = id;
            DBPersist.update(onevent);
        }

        public  void delete(long id)
        {
            OnEvent onevent = get(id);
            onevent.is_active = 0;
            DBPersist.update(onevent);
        }
    }
}

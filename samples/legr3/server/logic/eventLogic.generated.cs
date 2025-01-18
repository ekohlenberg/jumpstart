
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using ;

namespace 
{


    public partial class EventLogic : BaseLogic, IEventLogic
    {


        public static IEventLogic Create()
        {
            var event = new EventLogic();

            var proxy = DispatchProxy.Create<IEventLogic, Proxy<IEventLogic>>();
            ((Proxy<IEventLogic>)proxy).Initialize();
            ((Proxy<IEventLogic>)proxy).Target = event;

            return proxy;
        }



        public  List<Event> select()
        {
            Console.WriteLine("Processing EventLogic select List");

            List<Event> events = new List<Event>();

            void eventCallback(System.Data.Common.DbDataReader rdr)
            {
                Event event = new Event();

                DBPersist.autoAssign(rdr, event);

                events.Add(event);
            };

            DBPersist.select(eventCallback, $"select * from core.event");

            return events;
        }

        public  Event get(long id)
        {
            Console.WriteLine($"Processing EventLogic get ID={id}");

            Event event = new Event();
            event.id = id;

            DBPersist.get(event);

            return event;
        }

        public  void insert(Event event)
        {
            Console.WriteLine($"Processing EventLogic insert: {event}");

            event.is_active = 1;

            DBPersist.insert(event);
        }

        public  void update(long id, Event event)
        {
            Console.WriteLine($"Processing EventLogic update: ID = {id}\n{event}");

            event.id = id;
            DBPersist.update(event);
        }

        public  void delete(long id)
        {
            Event event = get(id);
            event.is_active = 0;
            DBPersist.update(event);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using legr3;

namespace legr3
{


    public partial class EventServiceLogic : BaseLogic, IEventServiceLogic
    {


        public static IEventServiceLogic Create()
        {
            var eventservice = new EventServiceLogic();

            var proxy = DispatchProxy.Create<IEventServiceLogic, Proxy<IEventServiceLogic>>();
            ((Proxy<IEventServiceLogic>)proxy).Initialize();
            ((Proxy<IEventServiceLogic>)proxy).Target = eventservice;

            return proxy;
        }



        public  List<EventService> select()
        {
            Console.WriteLine("Processing EventServiceLogic select List");

            List<EventService> eventservices = new List<EventService>();

            void eventserviceCallback(System.Data.Common.DbDataReader rdr)
            {
                EventService eventservice = new EventService();

                DBPersist.autoAssign(rdr, eventservice);

                eventservices.Add(eventservice);
            };

            DBPersist.select(eventserviceCallback, $"select * from core.event_service");

            return eventservices;
        }

        public  EventService get(long id)
        {
            Console.WriteLine($"Processing EventServiceLogic get ID={id}");

            EventService eventservice = new EventService();
            eventservice.id = id;

            DBPersist.get(eventservice);

            return eventservice;
        }

        public  void insert(EventService eventservice)
        {
            Console.WriteLine($"Processing EventServiceLogic insert: {eventservice}");

            eventservice.is_active = 1;

            DBPersist.insert(eventservice);
        }

        public  void update(long id, EventService eventservice)
        {
            Console.WriteLine($"Processing EventServiceLogic update: ID = {id}\n{eventservice}");

            eventservice.id = id;
            DBPersist.update(eventservice);
        }

        public  void delete(long id)
        {
            EventService eventservice = get(id);
            eventservice.is_active = 0;
            DBPersist.update(eventservice);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3
{
    public partial class EventServiceTest : BaseTest
    {
        public static void testInsert()
        {
            var eventservice = new EventService();


                    eventservice.op_id = BaseTest.getLastId("operation");
                    
                    eventservice.script_id = BaseTest.getLastId("script");
                    
                Console.WriteLine("Testing EventServiceLogic insert: " + eventservice.ToString());
                EventServiceLogic.Create().insert(eventservice);
                BaseTest.addLastId("event_service", eventservice.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("EventService");
            var eventservice = EventServiceLogic.Create().get(lastId);


                            eventservice.op_id = BaseTest.getLastId("operation");
                        
                            eventservice.script_id = BaseTest.getLastId("script");
                        
                Console.WriteLine("Testing EventServiceLogic update: " + eventservice.ToString());
                EventServiceLogic.Create().update(lastId, eventservice);
                    }
    }
}

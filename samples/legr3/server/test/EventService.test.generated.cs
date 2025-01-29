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


                    eventservice.event_type = Convert.ToString(BaseTest.getTestData(eventservice, "VARCHAR", TestDataType.random));
                    
                    eventservice.objectname_filter = Convert.ToString(BaseTest.getTestData(eventservice, "VARCHAR", TestDataType.random));
                    
                    eventservice.methodname_filter = Convert.ToString(BaseTest.getTestData(eventservice, "VARCHAR", TestDataType.random));
                    
                    eventservice.script_id = BaseTest.getLastId("script");
                    
                Console.WriteLine("Testing EventServiceLogic insert: " + eventservice.ToString());
                EventServiceLogic.Create().insert(eventservice);
                BaseTest.addLastId("event_service", eventservice.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("EventService");
            var eventservice = EventServiceLogic.Create().get(lastId);


                        eventservice.event_type = (string) BaseTest.getTestData(eventservice, "VARCHAR", TestDataType.random);
                    
                        eventservice.objectname_filter = (string) BaseTest.getTestData(eventservice, "VARCHAR", TestDataType.random);
                    
                        eventservice.methodname_filter = (string) BaseTest.getTestData(eventservice, "VARCHAR", TestDataType.random);
                    
                            eventservice.script_id = BaseTest.getLastId("script");
                        
                Console.WriteLine("Testing EventServiceLogic update: " + eventservice.ToString());
                EventServiceLogic.Create().update(lastId, eventservice);
                    }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ;

namespace 
{
    public partial class EventTest : BaseTest
    {
        public static void testInsert()
        {
            var event = new Event();


                    event.object = Convert.ToString(BaseTest.getTestData(event, "VARCHAR", TestDataType.random));
                    
                    event.method = Convert.ToString(BaseTest.getTestData(event, "VARCHAR", TestDataType.random));
                    
                    event.script_id = BaseTest.getLastId("script");
                    
                Console.WriteLine("Testing EventLogic insert: " + event.ToString());
                EventLogic.Create().insert(event);
                BaseTest.addLastId("Event", event.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Event");
            var event = EventLogic.Create().get(lastId);


                        event.object = (string) BaseTest.getTestData(event, "VARCHAR", TestDataType.random);
                    
                        event.method = (string) BaseTest.getTestData(event, "VARCHAR", TestDataType.random);
                    
                            event.script_id = BaseTest.getLastId("script");
                        
                Console.WriteLine("Testing EventLogic update: " + event.ToString());
                EventLogic.Create().update(lastId, event);
                    }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class MetricEventTest : BaseTest
    {
        public static void testInsert()
        {
            var metricevent = new MetricEvent();


                    metricevent.metric_id = BaseTest.getLastId("metric");
                    
                    metricevent.event_time = Convert.ToDateTime(BaseTest.getTestData(metricevent, "TIMESTAMP", TestDataType.random));
                    
                    metricevent.value = Convert.ToDouble(BaseTest.getTestData(metricevent, "NUMERIC(18,4)", TestDataType.random));
                    
                Console.WriteLine("Testing MetricEventLogic insert: " + metricevent.ToString());
                MetricEventLogic.Create().insert(metricevent);
                BaseTest.addLastId("metric_event", metricevent.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("MetricEvent");
            var metricevent = MetricEventLogic.Create().get(lastId);


                            metricevent.metric_id = BaseTest.getLastId("metric");
                        
                        metricevent.event_time = (DateTime) BaseTest.getTestData(metricevent, "TIMESTAMP", TestDataType.random);
                    
                        metricevent.value = (object) BaseTest.getTestData(metricevent, "NUMERIC(18,4)", TestDataType.random);
                    
                Console.WriteLine("Testing MetricEventLogic update: " + metricevent.ToString());
                MetricEventLogic.Create().update(lastId, metricevent);
                    }
    }
}

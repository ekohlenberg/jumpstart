using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class MetricTest : BaseTest
    {
        public static void testInsert()
        {
            var metric = new Metric();


                    metric.name = Convert.ToString(BaseTest.getTestData(metric, "VARCHAR", TestDataType.random));
                    
                    metric.category_id = BaseTest.getLastId("category");
                    
                    metric.uom_id = BaseTest.getLastId("uom");
                    
                Console.WriteLine("Testing MetricLogic insert: " + metric.ToString());
                MetricLogic.Create().insert(metric);
                BaseTest.addLastId("metric", metric.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Metric");
            var metric = MetricLogic.Create().get(lastId);


                        metric.name = (string) BaseTest.getTestData(metric, "VARCHAR", TestDataType.random);
                    
                            metric.category_id = BaseTest.getLastId("category");
                        
                            metric.uom_id = BaseTest.getLastId("uom");
                        
                Console.WriteLine("Testing MetricLogic update: " + metric.ToString());
                MetricLogic.Create().update(lastId, metric);
                    }
    }
}

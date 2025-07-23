using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge
{
    public partial class ScheduleTest : BaseTest
    {
        public static void testInsert()
        {
            var schedule = new Schedule();


                    schedule.cron_expression = Convert.ToString(BaseTest.getTestData(schedule, "VARCHAR", TestDataType.random));
                    
                    schedule.next_run_time = Convert.ToDateTime(BaseTest.getTestData(schedule, "TIMESTAMP", TestDataType.random));
                    
                    schedule.last_run_time = Convert.ToDateTime(BaseTest.getTestData(schedule, "TIMESTAMP", TestDataType.random));
                    
                    schedule.status = Convert.ToString(BaseTest.getTestData(schedule, "VARCHAR", TestDataType.random));
                    
                Console.WriteLine("Testing ScheduleLogic insert: " + schedule.ToString());
                ScheduleLogic.Create().insert(schedule);
                BaseTest.addLastId("schedule", schedule.id);
                    }

        public static void testUpdate()
        {
            long lastId = BaseTest.getLastId("Schedule");
            var schedule = ScheduleLogic.Create().get(lastId);


                        schedule.cron_expression = (string) BaseTest.getTestData(schedule, "VARCHAR", TestDataType.random);
                    
                        schedule.next_run_time = (DateTime) BaseTest.getTestData(schedule, "TIMESTAMP", TestDataType.random);
                    
                        schedule.last_run_time = (DateTime) BaseTest.getTestData(schedule, "TIMESTAMP", TestDataType.random);
                    
                        schedule.status = (string) BaseTest.getTestData(schedule, "VARCHAR", TestDataType.random);
                    
                Console.WriteLine("Testing ScheduleLogic update: " + schedule.ToString());
                ScheduleLogic.Create().update(lastId, schedule);
                    }
    }
}

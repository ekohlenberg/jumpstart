
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using defarge;

namespace defarge
{


    public partial class ScheduleLogic : IScheduleLogic
    {


        public static IScheduleLogic Create()
        {
            var schedule = new ScheduleLogic();

            var proxy = DispatchProxy.Create<IScheduleLogic, Proxy<IScheduleLogic>>();
            ((Proxy<IScheduleLogic>)proxy).Initialize();
            ((Proxy<IScheduleLogic>)proxy).Target = schedule;
            ((Proxy<IScheduleLogic>)proxy).DomainObj = "Schedule";

            return proxy;
        }



        public  List<Schedule> select()
        {
            Console.WriteLine("Processing ScheduleLogic select List");

            List<Schedule> schedules = new List<Schedule>();

            void scheduleCallback(System.Data.Common.DbDataReader rdr)
            {
                Schedule schedule = new Schedule();

                DBPersist.autoAssign(rdr, schedule);

                schedules.Add(schedule);
            };

            DBPersist.select(scheduleCallback, $"select * from core.schedule");

            return schedules;
        }

        public  Schedule get(long id)
        {
            Console.WriteLine($"Processing ScheduleLogic get ID={id}");

            Schedule schedule = new Schedule();
            schedule.id = id;

            DBPersist.get(schedule);

            return schedule;
        }

        public  void insert(Schedule schedule)
        {
            Console.WriteLine($"Processing ScheduleLogic insert: {schedule}");

            schedule.is_active = 1;

            DBPersist.insert(schedule);
        }

        public  void update(long id, Schedule schedule)
        {
            Console.WriteLine($"Processing ScheduleLogic update: ID = {id}\n{schedule}");

            schedule.id = id;
            DBPersist.update(schedule);
        }

        public  void delete(long id)
        {
            Schedule schedule = get(id);
            schedule.is_active = 0;
            DBPersist.update(schedule);
        }
    }
}

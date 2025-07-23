
using System;


namespace defarge
{
    public interface IScheduleLogic
    {  
        // Generated methods
        List<Schedule> select();
        Schedule get(long id);
        void insert(Schedule schedule);
        void update(long id, Schedule schedule);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class ScheduleLogic
    {
        public ScheduleLogic()
        {
           
        }
        
    }
}


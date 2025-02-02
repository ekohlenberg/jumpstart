
using System;


namespace defarge
{
    public interface IEventServiceLogic
    {  
        // Generated methods
        List<EventService> select();
        EventService get(long id);
        void insert(EventService eventservice);
        void update(long id, EventService eventservice);
        void delete( long id );
        //string getDomainName();
        // Add user-defined methods here
    }


    public partial class EventServiceLogic
    {
        public EventServiceLogic()
        {
           
        }
        
    }
}


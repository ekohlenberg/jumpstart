
using System;


namespace legr3
{
    public interface IEventServiceLogic
    {
        List<EventService> select();
        EventService get(long id);
        void insert(EventService eventservice);
        void update(long id, EventService eventservice);
        void delete( long id );
    }


    public partial class EventServiceLogic
    {
        public EventServiceLogic()
        {
           
        }
        
    }
}


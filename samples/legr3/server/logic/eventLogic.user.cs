
using System;


namespace 
{
    public interface IEventLogic
    {
        List<Event> select();
        Event get(long id);
        void insert(Event event);
        void update(long id, Event event);
        void delete( long id );
    }


    public partial class EventLogic
    {
        public EventLogic()
        {
           
        }
        
    }
}


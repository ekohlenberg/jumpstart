
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ;

namespace .Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        // GET: api/<EventController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            Console.WriteLine("Processing GET List");

            List<Event> events = EventLogic.Create().select();

            return events;
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public Event Get(long id)
        {
            Console.WriteLine($"Processing Event GET ID={id}");

            Event event = EventLogic.Create().get(id);

            return event;
        }

        // POST api/<EventController>
        [HttpPost]
        public void Post([FromBody] Event event)
        {
            Console.WriteLine($"Processing Event POST: {event}");
            EventLogic.Create().insert(event);
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Event event)
        {
            Console.WriteLine($"Processing Event PUT: ID = {id}\n{event}");
            EventLogic.Create().update(id, event);
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            EventLogic.Create().delete(id);
        }
    }
}

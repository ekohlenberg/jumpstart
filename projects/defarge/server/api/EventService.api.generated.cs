
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventServiceController : ControllerBase
    {
        // GET: api/<EventServiceController>
        [HttpGet]
        public IEnumerable<EventService> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<EventService> eventservices = EventServiceLogic.Create().select();

            return eventservices;
        }

        // GET api/<EventServiceController>/5
        [HttpGet("{id}")]
        public EventService Get(long id)
        {
            //Console.WriteLine($"Processing EventService GET ID={id}");

            EventService eventservice = EventServiceLogic.Create().get(id);

            return eventservice;
        }

        // POST api/<EventServiceController>
        [HttpPost]
        public void Post([FromBody] EventService eventservice)
        {
            //Console.WriteLine($"Processing EventService POST: {eventservice}");
            EventServiceLogic.Create().insert(eventservice);
        }

        // PUT api/<EventServiceController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] EventService eventservice)
        {
            //Console.WriteLine($"Processing EventService PUT: ID = {id}\n{eventservice}");
            EventServiceLogic.Create().update(id, eventservice);
        }

        // DELETE api/<EventServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            EventServiceLogic.Create().delete(id);
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnEventController : ControllerBase
    {
        // GET: api/<OnEventController>
        [HttpGet]
        public IEnumerable<OnEvent> Get()
        {
            Console.WriteLine("Processing GET List");

            List<OnEvent> onevents = OnEventLogic.Create().select();

            return onevents;
        }

        // GET api/<OnEventController>/5
        [HttpGet("{id}")]
        public OnEvent Get(long id)
        {
            Console.WriteLine($"Processing OnEvent GET ID={id}");

            OnEvent onevent = OnEventLogic.Create().get(id);

            return onevent;
        }

        // POST api/<OnEventController>
        [HttpPost]
        public void Post([FromBody] OnEvent onevent)
        {
            Console.WriteLine($"Processing OnEvent POST: {onevent}");
            OnEventLogic.Create().insert(onevent);
        }

        // PUT api/<OnEventController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] OnEvent onevent)
        {
            Console.WriteLine($"Processing OnEvent PUT: ID = {id}\n{onevent}");
            OnEventLogic.Create().update(id, onevent);
        }

        // DELETE api/<OnEventController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            OnEventLogic.Create().delete(id);
        }
    }
}

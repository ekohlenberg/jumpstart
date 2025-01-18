
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
    public class ActionController : ControllerBase
    {
        // GET: api/<ActionController>
        [HttpGet]
        public IEnumerable<Action> Get()
        {
            Console.WriteLine("Processing GET List");

            List<Action> actions = ActionLogic.Create().select();

            return actions;
        }

        // GET api/<ActionController>/5
        [HttpGet("{id}")]
        public Action Get(long id)
        {
            Console.WriteLine($"Processing Action GET ID={id}");

            Action action = ActionLogic.Create().get(id);

            return action;
        }

        // POST api/<ActionController>
        [HttpPost]
        public void Post([FromBody] Action action)
        {
            Console.WriteLine($"Processing Action POST: {action}");
            ActionLogic.Create().insert(action);
        }

        // PUT api/<ActionController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Action action)
        {
            Console.WriteLine($"Processing Action PUT: ID = {id}\n{action}");
            ActionLogic.Create().update(id, action);
        }

        // DELETE api/<ActionController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ActionLogic.Create().delete(id);
        }
    }
}

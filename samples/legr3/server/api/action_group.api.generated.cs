
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
    public class ActionGroupController : ControllerBase
    {
        // GET: api/<ActionGroupController>
        [HttpGet]
        public IEnumerable<ActionGroup> Get()
        {
            Console.WriteLine("Processing GET List");

            List<ActionGroup> actiongroups = ActionGroupLogic.Create().select();

            return actiongroups;
        }

        // GET api/<ActionGroupController>/5
        [HttpGet("{id}")]
        public ActionGroup Get(long id)
        {
            Console.WriteLine($"Processing ActionGroup GET ID={id}");

            ActionGroup actiongroup = ActionGroupLogic.Create().get(id);

            return actiongroup;
        }

        // POST api/<ActionGroupController>
        [HttpPost]
        public void Post([FromBody] ActionGroup actiongroup)
        {
            Console.WriteLine($"Processing ActionGroup POST: {actiongroup}");
            ActionGroupLogic.Create().insert(actiongroup);
        }

        // PUT api/<ActionGroupController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] ActionGroup actiongroup)
        {
            Console.WriteLine($"Processing ActionGroup PUT: ID = {id}\n{actiongroup}");
            ActionGroupLogic.Create().update(id, actiongroup);
        }

        // DELETE api/<ActionGroupController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ActionGroupLogic.Create().delete(id);
        }
    }
}

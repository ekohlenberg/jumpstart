
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
    public class ActionGroupMapController : ControllerBase
    {
        // GET: api/<ActionGroupMapController>
        [HttpGet]
        public IEnumerable<ActionGroupMap> Get()
        {
            Console.WriteLine("Processing GET List");

            List<ActionGroupMap> actiongroupmaps = ActionGroupMapLogic.Create().select();

            return actiongroupmaps;
        }

        // GET api/<ActionGroupMapController>/5
        [HttpGet("{id}")]
        public ActionGroupMap Get(long id)
        {
            Console.WriteLine($"Processing ActionGroupMap GET ID={id}");

            ActionGroupMap actiongroupmap = ActionGroupMapLogic.Create().get(id);

            return actiongroupmap;
        }

        // POST api/<ActionGroupMapController>
        [HttpPost]
        public void Post([FromBody] ActionGroupMap actiongroupmap)
        {
            Console.WriteLine($"Processing ActionGroupMap POST: {actiongroupmap}");
            ActionGroupMapLogic.Create().insert(actiongroupmap);
        }

        // PUT api/<ActionGroupMapController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] ActionGroupMap actiongroupmap)
        {
            Console.WriteLine($"Processing ActionGroupMap PUT: ID = {id}\n{actiongroupmap}");
            ActionGroupMapLogic.Create().update(id, actiongroupmap);
        }

        // DELETE api/<ActionGroupMapController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ActionGroupMapLogic.Create().delete(id);
        }
    }
}

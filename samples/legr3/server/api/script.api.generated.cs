
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
    public class ScriptController : ControllerBase
    {
        // GET: api/<ScriptController>
        [HttpGet]
        public IEnumerable<Script> Get()
        {
            Console.WriteLine("Processing GET List");

            List<Script> scripts = ScriptLogic.Create().select();

            return scripts;
        }

        // GET api/<ScriptController>/5
        [HttpGet("{id}")]
        public Script Get(long id)
        {
            Console.WriteLine($"Processing Script GET ID={id}");

            Script script = ScriptLogic.Create().get(id);

            return script;
        }

        // POST api/<ScriptController>
        [HttpPost]
        public void Post([FromBody] Script script)
        {
            Console.WriteLine($"Processing Script POST: {script}");
            ScriptLogic.Create().insert(script);
        }

        // PUT api/<ScriptController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Script script)
        {
            Console.WriteLine($"Processing Script PUT: ID = {id}\n{script}");
            ScriptLogic.Create().update(id, script);
        }

        // DELETE api/<ScriptController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ScriptLogic.Create().delete(id);
        }
    }
}

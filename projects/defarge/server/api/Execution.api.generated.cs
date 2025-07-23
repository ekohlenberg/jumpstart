
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
    public class ExecutionController : ControllerBase
    {
        // GET: api/<ExecutionController>
        [HttpGet]
        public IEnumerable<Execution> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Execution> executions = ExecutionLogic.Create().select();

            return executions;
        }

        // GET api/<ExecutionController>/5
        [HttpGet("{id}")]
        public Execution Get(long id)
        {
            //Console.WriteLine($"Processing Execution GET ID={id}");

            Execution execution = ExecutionLogic.Create().get(id);

            return execution;
        }

        // POST api/<ExecutionController>
        [HttpPost]
        public void Post([FromBody] Execution execution)
        {
            //Console.WriteLine($"Processing Execution POST: {execution}");
            ExecutionLogic.Create().insert(execution);
        }

        // PUT api/<ExecutionController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Execution execution)
        {
            //Console.WriteLine($"Processing Execution PUT: ID = {id}\n{execution}");
            ExecutionLogic.Create().update(id, execution);
        }

        // DELETE api/<ExecutionController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ExecutionLogic.Create().delete(id);
        }
    }
}

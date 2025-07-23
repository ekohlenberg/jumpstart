
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
    public class WorkflowController : ControllerBase
    {
        // GET: api/<WorkflowController>
        [HttpGet]
        public IEnumerable<Workflow> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Workflow> workflows = WorkflowLogic.Create().select();

            return workflows;
        }

        // GET api/<WorkflowController>/5
        [HttpGet("{id}")]
        public Workflow Get(long id)
        {
            //Console.WriteLine($"Processing Workflow GET ID={id}");

            Workflow workflow = WorkflowLogic.Create().get(id);

            return workflow;
        }

        // POST api/<WorkflowController>
        [HttpPost]
        public void Post([FromBody] Workflow workflow)
        {
            //Console.WriteLine($"Processing Workflow POST: {workflow}");
            WorkflowLogic.Create().insert(workflow);
        }

        // PUT api/<WorkflowController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Workflow workflow)
        {
            //Console.WriteLine($"Processing Workflow PUT: ID = {id}\n{workflow}");
            WorkflowLogic.Create().update(id, workflow);
        }

        // DELETE api/<WorkflowController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            WorkflowLogic.Create().delete(id);
        }
    }
}

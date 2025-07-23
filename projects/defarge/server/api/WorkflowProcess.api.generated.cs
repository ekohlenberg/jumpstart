
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
    public class WorkflowProcessController : ControllerBase
    {
        // GET: api/<WorkflowProcessController>
        [HttpGet]
        public IEnumerable<WorkflowProcess> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<WorkflowProcess> workflowprocesss = WorkflowProcessLogic.Create().select();

            return workflowprocesss;
        }

        // GET api/<WorkflowProcessController>/5
        [HttpGet("{id}")]
        public WorkflowProcess Get(long id)
        {
            //Console.WriteLine($"Processing WorkflowProcess GET ID={id}");

            WorkflowProcess workflowprocess = WorkflowProcessLogic.Create().get(id);

            return workflowprocess;
        }

        // POST api/<WorkflowProcessController>
        [HttpPost]
        public void Post([FromBody] WorkflowProcess workflowprocess)
        {
            //Console.WriteLine($"Processing WorkflowProcess POST: {workflowprocess}");
            WorkflowProcessLogic.Create().insert(workflowprocess);
        }

        // PUT api/<WorkflowProcessController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] WorkflowProcess workflowprocess)
        {
            //Console.WriteLine($"Processing WorkflowProcess PUT: ID = {id}\n{workflowprocess}");
            WorkflowProcessLogic.Create().update(id, workflowprocess);
        }

        // DELETE api/<WorkflowProcessController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            WorkflowProcessLogic.Create().delete(id);
        }
    }
}

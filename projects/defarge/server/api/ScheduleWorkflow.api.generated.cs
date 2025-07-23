
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
    public class ScheduleWorkflowController : ControllerBase
    {
        // GET: api/<ScheduleWorkflowController>
        [HttpGet]
        public IEnumerable<ScheduleWorkflow> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<ScheduleWorkflow> scheduleworkflows = ScheduleWorkflowLogic.Create().select();

            return scheduleworkflows;
        }

        // GET api/<ScheduleWorkflowController>/5
        [HttpGet("{id}")]
        public ScheduleWorkflow Get(long id)
        {
            //Console.WriteLine($"Processing ScheduleWorkflow GET ID={id}");

            ScheduleWorkflow scheduleworkflow = ScheduleWorkflowLogic.Create().get(id);

            return scheduleworkflow;
        }

        // POST api/<ScheduleWorkflowController>
        [HttpPost]
        public void Post([FromBody] ScheduleWorkflow scheduleworkflow)
        {
            //Console.WriteLine($"Processing ScheduleWorkflow POST: {scheduleworkflow}");
            ScheduleWorkflowLogic.Create().insert(scheduleworkflow);
        }

        // PUT api/<ScheduleWorkflowController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] ScheduleWorkflow scheduleworkflow)
        {
            //Console.WriteLine($"Processing ScheduleWorkflow PUT: ID = {id}\n{scheduleworkflow}");
            ScheduleWorkflowLogic.Create().update(id, scheduleworkflow);
        }

        // DELETE api/<ScheduleWorkflowController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ScheduleWorkflowLogic.Create().delete(id);
        }
    }
}

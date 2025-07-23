
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
    public class ScheduleController : ControllerBase
    {
        // GET: api/<ScheduleController>
        [HttpGet]
        public IEnumerable<Schedule> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Schedule> schedules = ScheduleLogic.Create().select();

            return schedules;
        }

        // GET api/<ScheduleController>/5
        [HttpGet("{id}")]
        public Schedule Get(long id)
        {
            //Console.WriteLine($"Processing Schedule GET ID={id}");

            Schedule schedule = ScheduleLogic.Create().get(id);

            return schedule;
        }

        // POST api/<ScheduleController>
        [HttpPost]
        public void Post([FromBody] Schedule schedule)
        {
            //Console.WriteLine($"Processing Schedule POST: {schedule}");
            ScheduleLogic.Create().insert(schedule);
        }

        // PUT api/<ScheduleController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Schedule schedule)
        {
            //Console.WriteLine($"Processing Schedule PUT: ID = {id}\n{schedule}");
            ScheduleLogic.Create().update(id, schedule);
        }

        // DELETE api/<ScheduleController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ScheduleLogic.Create().delete(id);
        }
    }
}

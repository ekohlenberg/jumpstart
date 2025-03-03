
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
    public class MetricEventController : ControllerBase
    {
        // GET: api/<MetricEventController>
        [HttpGet]
        public IEnumerable<MetricEvent> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<MetricEvent> metricevents = MetricEventLogic.Create().select();

            return metricevents;
        }

        // GET api/<MetricEventController>/5
        [HttpGet("{id}")]
        public MetricEvent Get(long id)
        {
            //Console.WriteLine($"Processing MetricEvent GET ID={id}");

            MetricEvent metricevent = MetricEventLogic.Create().get(id);

            return metricevent;
        }

        // POST api/<MetricEventController>
        [HttpPost]
        public void Post([FromBody] MetricEvent metricevent)
        {
            //Console.WriteLine($"Processing MetricEvent POST: {metricevent}");
            MetricEventLogic.Create().insert(metricevent);
        }

        // PUT api/<MetricEventController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] MetricEvent metricevent)
        {
            //Console.WriteLine($"Processing MetricEvent PUT: ID = {id}\n{metricevent}");
            MetricEventLogic.Create().update(id, metricevent);
        }

        // DELETE api/<MetricEventController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            MetricEventLogic.Create().delete(id);
        }
    }
}

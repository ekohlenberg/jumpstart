
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
    public class MetricController : ControllerBase
    {
        // GET: api/<MetricController>
        [HttpGet]
        public IEnumerable<Metric> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Metric> metrics = MetricLogic.Create().select();

            return metrics;
        }

        // GET api/<MetricController>/5
        [HttpGet("{id}")]
        public Metric Get(long id)
        {
            //Console.WriteLine($"Processing Metric GET ID={id}");

            Metric metric = MetricLogic.Create().get(id);

            return metric;
        }

        // POST api/<MetricController>
        [HttpPost]
        public void Post([FromBody] Metric metric)
        {
            //Console.WriteLine($"Processing Metric POST: {metric}");
            MetricLogic.Create().insert(metric);
        }

        // PUT api/<MetricController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Metric metric)
        {
            //Console.WriteLine($"Processing Metric PUT: ID = {id}\n{metric}");
            MetricLogic.Create().update(id, metric);
        }

        // DELETE api/<MetricController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            MetricLogic.Create().delete(id);
        }
    }
}

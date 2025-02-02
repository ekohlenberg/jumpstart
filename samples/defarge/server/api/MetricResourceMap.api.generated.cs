
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
    public class MetricResourceMapController : ControllerBase
    {
        // GET: api/<MetricResourceMapController>
        [HttpGet]
        public IEnumerable<MetricResourceMap> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<MetricResourceMap> metricresourcemaps = MetricResourceMapLogic.Create().select();

            return metricresourcemaps;
        }

        // GET api/<MetricResourceMapController>/5
        [HttpGet("{id}")]
        public MetricResourceMap Get(long id)
        {
            //Console.WriteLine($"Processing MetricResourceMap GET ID={id}");

            MetricResourceMap metricresourcemap = MetricResourceMapLogic.Create().get(id);

            return metricresourcemap;
        }

        // POST api/<MetricResourceMapController>
        [HttpPost]
        public void Post([FromBody] MetricResourceMap metricresourcemap)
        {
            //Console.WriteLine($"Processing MetricResourceMap POST: {metricresourcemap}");
            MetricResourceMapLogic.Create().insert(metricresourcemap);
        }

        // PUT api/<MetricResourceMapController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] MetricResourceMap metricresourcemap)
        {
            //Console.WriteLine($"Processing MetricResourceMap PUT: ID = {id}\n{metricresourcemap}");
            MetricResourceMapLogic.Create().update(id, metricresourcemap);
        }

        // DELETE api/<MetricResourceMapController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            MetricResourceMapLogic.Create().delete(id);
        }
    }
}

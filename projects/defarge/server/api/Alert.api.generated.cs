
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
    public class AlertController : ControllerBase
    {
        // GET: api/<AlertController>
        [HttpGet]
        public IEnumerable<Alert> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Alert> alerts = AlertLogic.Create().select();

            return alerts;
        }

        // GET api/<AlertController>/5
        [HttpGet("{id}")]
        public Alert Get(long id)
        {
            //Console.WriteLine($"Processing Alert GET ID={id}");

            Alert alert = AlertLogic.Create().get(id);

            return alert;
        }

        // POST api/<AlertController>
        [HttpPost]
        public void Post([FromBody] Alert alert)
        {
            //Console.WriteLine($"Processing Alert POST: {alert}");
            AlertLogic.Create().insert(alert);
        }

        // PUT api/<AlertController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Alert alert)
        {
            //Console.WriteLine($"Processing Alert PUT: ID = {id}\n{alert}");
            AlertLogic.Create().update(id, alert);
        }

        // DELETE api/<AlertController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            AlertLogic.Create().delete(id);
        }
    }
}

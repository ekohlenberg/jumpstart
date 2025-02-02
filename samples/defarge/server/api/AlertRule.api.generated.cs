
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
    public class AlertRuleController : ControllerBase
    {
        // GET: api/<AlertRuleController>
        [HttpGet]
        public IEnumerable<AlertRule> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<AlertRule> alertrules = AlertRuleLogic.Create().select();

            return alertrules;
        }

        // GET api/<AlertRuleController>/5
        [HttpGet("{id}")]
        public AlertRule Get(long id)
        {
            //Console.WriteLine($"Processing AlertRule GET ID={id}");

            AlertRule alertrule = AlertRuleLogic.Create().get(id);

            return alertrule;
        }

        // POST api/<AlertRuleController>
        [HttpPost]
        public void Post([FromBody] AlertRule alertrule)
        {
            //Console.WriteLine($"Processing AlertRule POST: {alertrule}");
            AlertRuleLogic.Create().insert(alertrule);
        }

        // PUT api/<AlertRuleController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] AlertRule alertrule)
        {
            //Console.WriteLine($"Processing AlertRule PUT: ID = {id}\n{alertrule}");
            AlertRuleLogic.Create().update(id, alertrule);
        }

        // DELETE api/<AlertRuleController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            AlertRuleLogic.Create().delete(id);
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr3;

namespace legr3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        // GET: api/<BudgetController>
        [HttpGet]
        public IEnumerable<Budget> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Budget> budgets = BudgetLogic.Create().select();

            return budgets;
        }

        // GET api/<BudgetController>/5
        [HttpGet("{id}")]
        public Budget Get(long id)
        {
            //Console.WriteLine($"Processing Budget GET ID={id}");

            Budget budget = BudgetLogic.Create().get(id);

            return budget;
        }

        // POST api/<BudgetController>
        [HttpPost]
        public void Post([FromBody] Budget budget)
        {
            //Console.WriteLine($"Processing Budget POST: {budget}");
            BudgetLogic.Create().insert(budget);
        }

        // PUT api/<BudgetController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Budget budget)
        {
            //Console.WriteLine($"Processing Budget PUT: ID = {id}\n{budget}");
            BudgetLogic.Create().update(id, budget);
        }

        // DELETE api/<BudgetController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            BudgetLogic.Create().delete(id);
        }
    }
}

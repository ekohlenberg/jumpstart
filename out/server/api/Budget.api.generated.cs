using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legr;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace legr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        // GET: api/<BudgetController>
        [HttpGet]
        public IEnumerable<Budget> Get()
        {
            Console.WriteLine("Processing  GET List" );

            List<Budget> budgets = BudgetLogic.select();

            return budgets;
        }

        // GET api/<BudgetController>/5
        [HttpGet("{id}")]
        public Budget Get(long id)
        {
            Console.WriteLine("Processing Budget GET ID=" + id.ToString());

            Budget budget = BudgetLogic.get(id);
           
            return budget;
        }

        // POST api/<BudgetController>
        [HttpPost]
        public void Post([FromBody] Budget budget)
        {
            Console.WriteLine("Processing Budget POST: " + budget.ToString()  );
            BudgetLogic.insert(budget);
        }

        // PUT api/<BudgetController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Budget budget)
        {
             Console.WriteLine("Processing Budget PUT: ID = " + id.ToString() + "\n" + budget.ToString()  );
            BudgetLogic.update( id, budget);
        }

        // DELETE api/<BudgetController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            BudgetLogic.delete( id );
        }
    }
}

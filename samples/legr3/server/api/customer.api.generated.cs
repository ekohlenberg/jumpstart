
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
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Customer> customers = CustomerLogic.Create().select();

            return customers;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer Get(long id)
        {
            //Console.WriteLine($"Processing Customer GET ID={id}");

            Customer customer = CustomerLogic.Create().get(id);

            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            //Console.WriteLine($"Processing Customer POST: {customer}");
            CustomerLogic.Create().insert(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Customer customer)
        {
            //Console.WriteLine($"Processing Customer PUT: ID = {id}\n{customer}");
            CustomerLogic.Create().update(id, customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            CustomerLogic.Create().delete(id);
        }
    }
}

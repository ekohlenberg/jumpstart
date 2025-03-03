
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
    public class PaymentController : ControllerBase
    {
        // GET: api/<PaymentController>
        [HttpGet]
        public IEnumerable<Payment> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Payment> payments = PaymentLogic.Create().select();

            return payments;
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public Payment Get(long id)
        {
            //Console.WriteLine($"Processing Payment GET ID={id}");

            Payment payment = PaymentLogic.Create().get(id);

            return payment;
        }

        // POST api/<PaymentController>
        [HttpPost]
        public void Post([FromBody] Payment payment)
        {
            //Console.WriteLine($"Processing Payment POST: {payment}");
            PaymentLogic.Create().insert(payment);
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Payment payment)
        {
            //Console.WriteLine($"Processing Payment PUT: ID = {id}\n{payment}");
            PaymentLogic.Create().update(id, payment);
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            PaymentLogic.Create().delete(id);
        }
    }
}

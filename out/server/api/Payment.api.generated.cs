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
    public class PaymentController : ControllerBase
    {
        // GET: api/<PaymentController>
        [HttpGet]
        public IEnumerable<Payment> Get()
        {
            Console.WriteLine("Processing  GET List" );

            List<Payment> payments = PaymentLogic.select();

            return payments;
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public Payment Get(long id)
        {
            Console.WriteLine("Processing Payment GET ID=" + id.ToString());

            Payment payment = PaymentLogic.get(id);
           
            return payment;
        }

        // POST api/<PaymentController>
        [HttpPost]
        public void Post([FromBody] Payment payment)
        {
            Console.WriteLine("Processing Payment POST: " + payment.ToString()  );
            PaymentLogic.insert(payment);
        }

        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Payment payment)
        {
             Console.WriteLine("Processing Payment PUT: ID = " + id.ToString() + "\n" + payment.ToString()  );
            PaymentLogic.update( id, payment);
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            PaymentLogic.delete( id );
        }
    }
}

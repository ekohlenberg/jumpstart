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
    public class InvoiceController : ControllerBase
    {
        // GET: api/<InvoiceController>
        [HttpGet]
        public IEnumerable<Invoice> Get()
        {
            Console.WriteLine("Processing  GET List" );

            List<Invoice> invoices = InvoiceLogic.select();

            return invoices;
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public Invoice Get(long id)
        {
            Console.WriteLine("Processing Invoice GET ID=" + id.ToString());

            Invoice invoice = InvoiceLogic.get(id);
           
            return invoice;
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public void Post([FromBody] Invoice invoice)
        {
            Console.WriteLine("Processing Invoice POST: " + invoice.ToString()  );
            InvoiceLogic.insert(invoice);
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Invoice invoice)
        {
             Console.WriteLine("Processing Invoice PUT: ID = " + id.ToString() + "\n" + invoice.ToString()  );
            InvoiceLogic.update( id, invoice);
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            InvoiceLogic.delete( id );
        }
    }
}

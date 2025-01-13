
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
    public class InvoiceItemController : ControllerBase
    {
        // GET: api/<InvoiceItemController>
        [HttpGet]
        public IEnumerable<InvoiceItem> Get()
        {
            Console.WriteLine("Processing GET List");

            List<InvoiceItem> invoiceitems = InvoiceItemLogic.Create().select();

            return invoiceitems;
        }

        // GET api/<InvoiceItemController>/5
        [HttpGet("{id}")]
        public InvoiceItem Get(long id)
        {
            Console.WriteLine($"Processing InvoiceItem GET ID={id}");

            InvoiceItem invoiceitem = InvoiceItemLogic.Create().get(id);

            return invoiceitem;
        }

        // POST api/<InvoiceItemController>
        [HttpPost]
        public void Post([FromBody] InvoiceItem invoiceitem)
        {
            Console.WriteLine($"Processing InvoiceItem POST: {invoiceitem}");
            InvoiceItemLogic.Create().insert(invoiceitem);
        }

        // PUT api/<InvoiceItemController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] InvoiceItem invoiceitem)
        {
            Console.WriteLine($"Processing InvoiceItem PUT: ID = {id}\n{invoiceitem}");
            InvoiceItemLogic.Create().update(id, invoiceitem);
        }

        // DELETE api/<InvoiceItemController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            InvoiceItemLogic.Create().delete(id);
        }
    }
}

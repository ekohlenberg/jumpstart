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
    public class BillItemController : ControllerBase
    {
        // GET: api/<BillItemController>
        [HttpGet]
        public IEnumerable<BillItem> Get()
        {
            Console.WriteLine("Processing  GET List" );

            List<BillItem> billitems = BillItemLogic.select();

            return billitems;
        }

        // GET api/<BillItemController>/5
        [HttpGet("{id}")]
        public BillItem Get(long id)
        {
            Console.WriteLine("Processing BillItem GET ID=" + id.ToString());

            BillItem billitem = BillItemLogic.get(id);
           
            return billitem;
        }

        // POST api/<BillItemController>
        [HttpPost]
        public void Post([FromBody] BillItem billitem)
        {
            Console.WriteLine("Processing BillItem POST: " + billitem.ToString()  );
            BillItemLogic.insert(billitem);
        }

        // PUT api/<BillItemController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] BillItem billitem)
        {
             Console.WriteLine("Processing BillItem PUT: ID = " + id.ToString() + "\n" + billitem.ToString()  );
            BillItemLogic.update( id, billitem);
        }

        // DELETE api/<BillItemController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            BillItemLogic.delete( id );
        }
    }
}

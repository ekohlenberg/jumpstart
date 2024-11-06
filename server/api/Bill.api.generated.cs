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
    public class BillController : ControllerBase
    {
        // GET: api/<BillController>
        [HttpGet]
        public IEnumerable<Bill> Get()
        {
            Console.WriteLine("Processing  GET List" );

            List<Bill> bills = BillLogic.select();

            return bills;
        }

        // GET api/<BillController>/5
        [HttpGet("{id}")]
        public Bill Get(long id)
        {
            Console.WriteLine("Processing Bill GET ID=" + id.ToString());

            Bill bill = BillLogic.get(id);
           
            return bill;
        }

        // POST api/<BillController>
        [HttpPost]
        public void Post([FromBody] Bill bill)
        {
            Console.WriteLine("Processing Bill POST: " + bill.ToString()  );
            BillLogic.insert(bill);
        }

        // PUT api/<BillController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Bill bill)
        {
             Console.WriteLine("Processing Bill PUT: ID = " + id.ToString() + "\n" + bill.ToString()  );
            BillLogic.update( id, bill);
        }

        // DELETE api/<BillController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            BillLogic.delete( id );
        }
    }
}

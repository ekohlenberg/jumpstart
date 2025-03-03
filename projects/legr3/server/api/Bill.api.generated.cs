
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
    public class BillController : ControllerBase
    {
        // GET: api/<BillController>
        [HttpGet]
        public IEnumerable<Bill> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Bill> bills = BillLogic.Create().select();

            return bills;
        }

        // GET api/<BillController>/5
        [HttpGet("{id}")]
        public Bill Get(long id)
        {
            //Console.WriteLine($"Processing Bill GET ID={id}");

            Bill bill = BillLogic.Create().get(id);

            return bill;
        }

        // POST api/<BillController>
        [HttpPost]
        public void Post([FromBody] Bill bill)
        {
            //Console.WriteLine($"Processing Bill POST: {bill}");
            BillLogic.Create().insert(bill);
        }

        // PUT api/<BillController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Bill bill)
        {
            //Console.WriteLine($"Processing Bill PUT: ID = {id}\n{bill}");
            BillLogic.Create().update(id, bill);
        }

        // DELETE api/<BillController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            BillLogic.Create().delete(id);
        }
    }
}

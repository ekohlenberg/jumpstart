
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
    public class BillItemController : ControllerBase
    {
        // GET: api/<BillItemController>
        [HttpGet]
        public IEnumerable<BillItem> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<BillItem> billitems = BillItemLogic.Create().select();

            return billitems;
        }

        // GET api/<BillItemController>/5
        [HttpGet("{id}")]
        public BillItem Get(long id)
        {
            //Console.WriteLine($"Processing BillItem GET ID={id}");

            BillItem billitem = BillItemLogic.Create().get(id);

            return billitem;
        }

        // POST api/<BillItemController>
        [HttpPost]
        public void Post([FromBody] BillItem billitem)
        {
            //Console.WriteLine($"Processing BillItem POST: {billitem}");
            BillItemLogic.Create().insert(billitem);
        }

        // PUT api/<BillItemController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] BillItem billitem)
        {
            //Console.WriteLine($"Processing BillItem PUT: ID = {id}\n{billitem}");
            BillItemLogic.Create().update(id, billitem);
        }

        // DELETE api/<BillItemController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            BillItemLogic.Create().delete(id);
        }
    }
}

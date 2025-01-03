
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
    public class VendorController : ControllerBase
    {
        // GET: api/<VendorController>
        [HttpGet]
        public IEnumerable<Vendor> Get()
        {
            Console.WriteLine("Processing GET List");

            List<Vendor> vendors = VendorLogic.select();

            return vendors;
        }

        // GET api/<VendorController>/5
        [HttpGet("{id}")]
        public Vendor Get(long id)
        {
            Console.WriteLine($"Processing Vendor GET ID={id}");

            Vendor vendor = VendorLogic.get(id);

            return vendor;
        }

        // POST api/<VendorController>
        [HttpPost]
        public void Post([FromBody] Vendor vendor)
        {
            Console.WriteLine($"Processing Vendor POST: {vendor}");
            VendorLogic.insert(vendor);
        }

        // PUT api/<VendorController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Vendor vendor)
        {
            Console.WriteLine($"Processing Vendor PUT: ID = {id}\n{vendor}");
            VendorLogic.update(id, vendor);
        }

        // DELETE api/<VendorController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            VendorLogic.delete(id);
        }
    }
}

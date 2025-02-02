
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UomController : ControllerBase
    {
        // GET: api/<UomController>
        [HttpGet]
        public IEnumerable<Uom> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Uom> uoms = UomLogic.Create().select();

            return uoms;
        }

        // GET api/<UomController>/5
        [HttpGet("{id}")]
        public Uom Get(long id)
        {
            //Console.WriteLine($"Processing Uom GET ID={id}");

            Uom uom = UomLogic.Create().get(id);

            return uom;
        }

        // POST api/<UomController>
        [HttpPost]
        public void Post([FromBody] Uom uom)
        {
            //Console.WriteLine($"Processing Uom POST: {uom}");
            UomLogic.Create().insert(uom);
        }

        // PUT api/<UomController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Uom uom)
        {
            //Console.WriteLine($"Processing Uom PUT: ID = {id}\n{uom}");
            UomLogic.Create().update(id, uom);
        }

        // DELETE api/<UomController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            UomLogic.Create().delete(id);
        }
    }
}

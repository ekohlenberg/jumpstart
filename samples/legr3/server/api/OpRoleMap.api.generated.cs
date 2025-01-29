
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
    public class OpRoleMapController : ControllerBase
    {
        // GET: api/<OpRoleMapController>
        [HttpGet]
        public IEnumerable<OpRoleMap> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<OpRoleMap> oprolemaps = OpRoleMapLogic.Create().select();

            return oprolemaps;
        }

        // GET api/<OpRoleMapController>/5
        [HttpGet("{id}")]
        public OpRoleMap Get(long id)
        {
            //Console.WriteLine($"Processing OpRoleMap GET ID={id}");

            OpRoleMap oprolemap = OpRoleMapLogic.Create().get(id);

            return oprolemap;
        }

        // POST api/<OpRoleMapController>
        [HttpPost]
        public void Post([FromBody] OpRoleMap oprolemap)
        {
            //Console.WriteLine($"Processing OpRoleMap POST: {oprolemap}");
            OpRoleMapLogic.Create().insert(oprolemap);
        }

        // PUT api/<OpRoleMapController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] OpRoleMap oprolemap)
        {
            //Console.WriteLine($"Processing OpRoleMap PUT: ID = {id}\n{oprolemap}");
            OpRoleMapLogic.Create().update(id, oprolemap);
        }

        // DELETE api/<OpRoleMapController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            OpRoleMapLogic.Create().delete(id);
        }
    }
}


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
    public class OpRoleController : ControllerBase
    {
        // GET: api/<OpRoleController>
        [HttpGet]
        public IEnumerable<OpRole> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<OpRole> oproles = OpRoleLogic.Create().select();

            return oproles;
        }

        // GET api/<OpRoleController>/5
        [HttpGet("{id}")]
        public OpRole Get(long id)
        {
            //Console.WriteLine($"Processing OpRole GET ID={id}");

            OpRole oprole = OpRoleLogic.Create().get(id);

            return oprole;
        }

        // POST api/<OpRoleController>
        [HttpPost]
        public void Post([FromBody] OpRole oprole)
        {
            //Console.WriteLine($"Processing OpRole POST: {oprole}");
            OpRoleLogic.Create().insert(oprole);
        }

        // PUT api/<OpRoleController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] OpRole oprole)
        {
            //Console.WriteLine($"Processing OpRole PUT: ID = {id}\n{oprole}");
            OpRoleLogic.Create().update(id, oprole);
        }

        // DELETE api/<OpRoleController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            OpRoleLogic.Create().delete(id);
        }
    }
}

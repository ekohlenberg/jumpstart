
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
    public class OrgController : ControllerBase
    {
        // GET: api/<OrgController>
        [HttpGet]
        public IEnumerable<Org> Get()
        {
            Console.WriteLine("Processing GET List");

            List<Org> orgs = OrgLogic.Create().select();

            return orgs;
        }

        // GET api/<OrgController>/5
        [HttpGet("{id}")]
        public Org Get(long id)
        {
            Console.WriteLine($"Processing Org GET ID={id}");

            Org org = OrgLogic.Create().get(id);

            return org;
        }

        // POST api/<OrgController>
        [HttpPost]
        public void Post([FromBody] Org org)
        {
            Console.WriteLine($"Processing Org POST: {org}");
            OrgLogic.Create().insert(org);
        }

        // PUT api/<OrgController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Org org)
        {
            Console.WriteLine($"Processing Org PUT: ID = {id}\n{org}");
            OrgLogic.Create().update(id, org);
        }

        // DELETE api/<OrgController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            OrgLogic.Create().delete(id);
        }
    }
}

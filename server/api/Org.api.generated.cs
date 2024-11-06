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
    public class OrgController : ControllerBase
    {
        // GET: api/<OrgController>
        [HttpGet]
        public IEnumerable<Org> Get()
        {
            Console.WriteLine("Processing  GET List" );

            List<Org> orgs = OrgLogic.select();

            return orgs;
        }

        // GET api/<OrgController>/5
        [HttpGet("{id}")]
        public Org Get(long id)
        {
            Console.WriteLine("Processing Org GET ID=" + id.ToString());

            Org org = OrgLogic.get(id);
           
            return org;
        }

        // POST api/<OrgController>
        [HttpPost]
        public void Post([FromBody] Org org)
        {
            Console.WriteLine("Processing Org POST: " + org.ToString()  );
            OrgLogic.insert(org);
        }

        // PUT api/<OrgController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Org org)
        {
             Console.WriteLine("Processing Org PUT: ID = " + id.ToString() + "\n" + org.ToString()  );
            OrgLogic.update( id, org);
        }

        // DELETE api/<OrgController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            OrgLogic.delete( id );
        }
    }
}

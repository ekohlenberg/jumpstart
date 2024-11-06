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
    public class UserOrgController : ControllerBase
    {
        // GET: api/<UserOrgController>
        [HttpGet]
        public IEnumerable<UserOrg> Get()
        {
            Console.WriteLine("Processing  GET List" );

            List<UserOrg> userorgs = UserOrgLogic.select();

            return userorgs;
        }

        // GET api/<UserOrgController>/5
        [HttpGet("{id}")]
        public UserOrg Get(long id)
        {
            Console.WriteLine("Processing UserOrg GET ID=" + id.ToString());

            UserOrg userorg = UserOrgLogic.get(id);
           
            return userorg;
        }

        // POST api/<UserOrgController>
        [HttpPost]
        public void Post([FromBody] UserOrg userorg)
        {
            Console.WriteLine("Processing UserOrg POST: " + userorg.ToString()  );
            UserOrgLogic.insert(userorg);
        }

        // PUT api/<UserOrgController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] UserOrg userorg)
        {
             Console.WriteLine("Processing UserOrg PUT: ID = " + id.ToString() + "\n" + userorg.ToString()  );
            UserOrgLogic.update( id, userorg);
        }

        // DELETE api/<UserOrgController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            UserOrgLogic.delete( id );
        }
    }
}


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
    public class OpRoleMemberController : ControllerBase
    {
        // GET: api/<OpRoleMemberController>
        [HttpGet]
        public IEnumerable<OpRoleMember> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<OpRoleMember> oprolemembers = OpRoleMemberLogic.Create().select();

            return oprolemembers;
        }

        // GET api/<OpRoleMemberController>/5
        [HttpGet("{id}")]
        public OpRoleMember Get(long id)
        {
            //Console.WriteLine($"Processing OpRoleMember GET ID={id}");

            OpRoleMember oprolemember = OpRoleMemberLogic.Create().get(id);

            return oprolemember;
        }

        // POST api/<OpRoleMemberController>
        [HttpPost]
        public void Post([FromBody] OpRoleMember oprolemember)
        {
            //Console.WriteLine($"Processing OpRoleMember POST: {oprolemember}");
            OpRoleMemberLogic.Create().insert(oprolemember);
        }

        // PUT api/<OpRoleMemberController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] OpRoleMember oprolemember)
        {
            //Console.WriteLine($"Processing OpRoleMember PUT: ID = {id}\n{oprolemember}");
            OpRoleMemberLogic.Create().update(id, oprolemember);
        }

        // DELETE api/<OpRoleMemberController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            OpRoleMemberLogic.Create().delete(id);
        }
    }
}

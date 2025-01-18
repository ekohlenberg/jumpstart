
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ;

namespace .Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActionGroupController : ControllerBase
    {
        // GET: api/<UserActionGroupController>
        [HttpGet]
        public IEnumerable<UserActionGroup> Get()
        {
            Console.WriteLine("Processing GET List");

            List<UserActionGroup> useractiongroups = UserActionGroupLogic.Create().select();

            return useractiongroups;
        }

        // GET api/<UserActionGroupController>/5
        [HttpGet("{id}")]
        public UserActionGroup Get(long id)
        {
            Console.WriteLine($"Processing UserActionGroup GET ID={id}");

            UserActionGroup useractiongroup = UserActionGroupLogic.Create().get(id);

            return useractiongroup;
        }

        // POST api/<UserActionGroupController>
        [HttpPost]
        public void Post([FromBody] UserActionGroup useractiongroup)
        {
            Console.WriteLine($"Processing UserActionGroup POST: {useractiongroup}");
            UserActionGroupLogic.Create().insert(useractiongroup);
        }

        // PUT api/<UserActionGroupController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] UserActionGroup useractiongroup)
        {
            Console.WriteLine($"Processing UserActionGroup PUT: ID = {id}\n{useractiongroup}");
            UserActionGroupLogic.Create().update(id, useractiongroup);
        }

        // DELETE api/<UserActionGroupController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            UserActionGroupLogic.Create().delete(id);
        }
    }
}

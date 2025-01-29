
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
    public class UserPasswordController : ControllerBase
    {
        // GET: api/<UserPasswordController>
        [HttpGet]
        public IEnumerable<UserPassword> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<UserPassword> userpasswords = UserPasswordLogic.Create().select();

            return userpasswords;
        }

        // GET api/<UserPasswordController>/5
        [HttpGet("{id}")]
        public UserPassword Get(long id)
        {
            //Console.WriteLine($"Processing UserPassword GET ID={id}");

            UserPassword userpassword = UserPasswordLogic.Create().get(id);

            return userpassword;
        }

        // POST api/<UserPasswordController>
        [HttpPost]
        public void Post([FromBody] UserPassword userpassword)
        {
            //Console.WriteLine($"Processing UserPassword POST: {userpassword}");
            UserPasswordLogic.Create().insert(userpassword);
        }

        // PUT api/<UserPasswordController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] UserPassword userpassword)
        {
            //Console.WriteLine($"Processing UserPassword PUT: ID = {id}\n{userpassword}");
            UserPasswordLogic.Create().update(id, userpassword);
        }

        // DELETE api/<UserPasswordController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            UserPasswordLogic.Create().delete(id);
        }
    }
}

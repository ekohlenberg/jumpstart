
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
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<User> users = UserLogic.Create().select();

            return users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(long id)
        {
            //Console.WriteLine($"Processing User GET ID={id}");

            User user = UserLogic.Create().get(id);

            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            //Console.WriteLine($"Processing User POST: {user}");
            UserLogic.Create().insert(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] User user)
        {
            //Console.WriteLine($"Processing User PUT: ID = {id}\n{user}");
            UserLogic.Create().update(id, user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            UserLogic.Create().delete(id);
        }
    }
}

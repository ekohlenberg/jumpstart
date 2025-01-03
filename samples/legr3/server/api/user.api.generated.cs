
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
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            Console.WriteLine("Processing GET List");

            List<User> users = UserLogic.select();

            return users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(long id)
        {
            Console.WriteLine($"Processing User GET ID={id}");

            User user = UserLogic.get(id);

            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            Console.WriteLine($"Processing User POST: {user}");
            UserLogic.insert(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] User user)
        {
            Console.WriteLine($"Processing User PUT: ID = {id}\n{user}");
            UserLogic.update(id, user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            UserLogic.delete(id);
        }
    }
}

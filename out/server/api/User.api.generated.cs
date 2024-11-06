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
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            Console.WriteLine("Processing  GET List" );

            List<User> users = UserLogic.select();

            return users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(long id)
        {
            Console.WriteLine("Processing User GET ID=" + id.ToString());

            User user = UserLogic.get(id);
           
            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            Console.WriteLine("Processing User POST: " + user.ToString()  );
            UserLogic.insert(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] User user)
        {
             Console.WriteLine("Processing User PUT: ID = " + id.ToString() + "\n" + user.ToString()  );
            UserLogic.update( id, user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            UserLogic.delete( id );
        }
    }
}

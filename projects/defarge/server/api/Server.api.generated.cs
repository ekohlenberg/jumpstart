
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
    public class ServerController : ControllerBase
    {
        // GET: api/<ServerController>
        [HttpGet]
        public IEnumerable<Server> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Server> servers = ServerLogic.Create().select();

            return servers;
        }

        // GET api/<ServerController>/5
        [HttpGet("{id}")]
        public Server Get(long id)
        {
            //Console.WriteLine($"Processing Server GET ID={id}");

            Server server = ServerLogic.Create().get(id);

            return server;
        }

        // POST api/<ServerController>
        [HttpPost]
        public void Post([FromBody] Server server)
        {
            //Console.WriteLine($"Processing Server POST: {server}");
            ServerLogic.Create().insert(server);
        }

        // PUT api/<ServerController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Server server)
        {
            //Console.WriteLine($"Processing Server PUT: ID = {id}\n{server}");
            ServerLogic.Create().update(id, server);
        }

        // DELETE api/<ServerController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ServerLogic.Create().delete(id);
        }
    }
}


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
    public class ResourceController : ControllerBase
    {
        // GET: api/<ResourceController>
        [HttpGet]
        public IEnumerable<Resource> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Resource> resources = ResourceLogic.Create().select();

            return resources;
        }

        // GET api/<ResourceController>/5
        [HttpGet("{id}")]
        public Resource Get(long id)
        {
            //Console.WriteLine($"Processing Resource GET ID={id}");

            Resource resource = ResourceLogic.Create().get(id);

            return resource;
        }

        // POST api/<ResourceController>
        [HttpPost]
        public void Post([FromBody] Resource resource)
        {
            //Console.WriteLine($"Processing Resource POST: {resource}");
            ResourceLogic.Create().insert(resource);
        }

        // PUT api/<ResourceController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Resource resource)
        {
            //Console.WriteLine($"Processing Resource PUT: ID = {id}\n{resource}");
            ResourceLogic.Create().update(id, resource);
        }

        // DELETE api/<ResourceController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ResourceLogic.Create().delete(id);
        }
    }
}

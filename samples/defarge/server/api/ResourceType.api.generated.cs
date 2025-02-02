
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
    public class ResourceTypeController : ControllerBase
    {
        // GET: api/<ResourceTypeController>
        [HttpGet]
        public IEnumerable<ResourceType> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<ResourceType> resourcetypes = ResourceTypeLogic.Create().select();

            return resourcetypes;
        }

        // GET api/<ResourceTypeController>/5
        [HttpGet("{id}")]
        public ResourceType Get(long id)
        {
            //Console.WriteLine($"Processing ResourceType GET ID={id}");

            ResourceType resourcetype = ResourceTypeLogic.Create().get(id);

            return resourcetype;
        }

        // POST api/<ResourceTypeController>
        [HttpPost]
        public void Post([FromBody] ResourceType resourcetype)
        {
            //Console.WriteLine($"Processing ResourceType POST: {resourcetype}");
            ResourceTypeLogic.Create().insert(resourcetype);
        }

        // PUT api/<ResourceTypeController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] ResourceType resourcetype)
        {
            //Console.WriteLine($"Processing ResourceType PUT: ID = {id}\n{resourcetype}");
            ResourceTypeLogic.Create().update(id, resourcetype);
        }

        // DELETE api/<ResourceTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ResourceTypeLogic.Create().delete(id);
        }
    }
}

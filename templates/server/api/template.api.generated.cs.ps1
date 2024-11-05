@"
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using $($namespace);

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace $($namespace).Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class $($domainObj)Controller : ControllerBase
    {
        // GET: api/<$($domainObj)Controller>
        [HttpGet]
        public IEnumerable<$($domainObj)> Get()
        {
            Console.WriteLine("Processing  GET List" );

            List<$($domainObj)> $($domainVar)s = $($domainObj)Logic.select();

            return $($domainVar)s;
        }

        // GET api/<$($domainObj)Controller>/5
        [HttpGet("{id}")]
        public $($domainObj) Get(long id)
        {
            Console.WriteLine("Processing $($domainObj) GET ID=" + id.ToString());

            $($domainObj) $($domainVar) = $($domainObj)Logic.get(id);
           
            return $($domainVar);
        }

        // POST api/<$($domainObj)Controller>
        [HttpPost]
        public void Post([FromBody] $($domainObj) $($domainVar))
        {
            Console.WriteLine("Processing $($domainObj) POST: " + $($domainVar).ToString()  );
            $($domainObj)Logic.insert($($domainVar));
        }

        // PUT api/<$($domainObj)Controller>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] $($domainObj) $($domainVar))
        {
             Console.WriteLine("Processing $($domainObj) PUT: ID = " + id.ToString() + "\n" + $($domainVar).ToString()  );
            $($domainObj)Logic.update( id, $($domainVar));
        }

        // DELETE api/<$($domainObj)Controller>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            $($domainObj)Logic.delete( id );
        }
    }
}
"@
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
    public class CategoryController : ControllerBase
    {
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            Console.WriteLine("Processing  GET List" );

            List<Category> categorys = CategoryLogic.select();

            return categorys;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(long id)
        {
            Console.WriteLine("Processing Category GET ID=" + id.ToString());

            Category category = CategoryLogic.get(id);
           
            return category;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            Console.WriteLine("Processing Category POST: " + category.ToString()  );
            CategoryLogic.insert(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Category category)
        {
             Console.WriteLine("Processing Category PUT: ID = " + id.ToString() + "\n" + category.ToString()  );
            CategoryLogic.update( id, category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            CategoryLogic.delete( id );
        }
    }
}

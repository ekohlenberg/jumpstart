
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
    public class CategoryController : ControllerBase
    {
        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            Console.WriteLine("Processing GET List");

            List<Category> categorys = CategoryLogic.Create().select();

            return categorys;
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category Get(long id)
        {
            Console.WriteLine($"Processing Category GET ID={id}");

            Category category = CategoryLogic.Create().get(id);

            return category;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            Console.WriteLine($"Processing Category POST: {category}");
            CategoryLogic.Create().insert(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Category category)
        {
            Console.WriteLine($"Processing Category PUT: ID = {id}\n{category}");
            CategoryLogic.Create().update(id, category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            CategoryLogic.Create().delete(id);
        }
    }
}


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
    public class TransactionCategoryController : ControllerBase
    {
        // GET: api/<TransactionCategoryController>
        [HttpGet]
        public IEnumerable<TransactionCategory> Get()
        {
            Console.WriteLine("Processing GET List");

            List<TransactionCategory> transactioncategorys = TransactionCategoryLogic.Create().select();

            return transactioncategorys;
        }

        // GET api/<TransactionCategoryController>/5
        [HttpGet("{id}")]
        public TransactionCategory Get(long id)
        {
            Console.WriteLine($"Processing TransactionCategory GET ID={id}");

            TransactionCategory transactioncategory = TransactionCategoryLogic.Create().get(id);

            return transactioncategory;
        }

        // POST api/<TransactionCategoryController>
        [HttpPost]
        public void Post([FromBody] TransactionCategory transactioncategory)
        {
            Console.WriteLine($"Processing TransactionCategory POST: {transactioncategory}");
            TransactionCategoryLogic.Create().insert(transactioncategory);
        }

        // PUT api/<TransactionCategoryController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] TransactionCategory transactioncategory)
        {
            Console.WriteLine($"Processing TransactionCategory PUT: ID = {id}\n{transactioncategory}");
            TransactionCategoryLogic.Create().update(id, transactioncategory);
        }

        // DELETE api/<TransactionCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            TransactionCategoryLogic.Create().delete(id);
        }
    }
}

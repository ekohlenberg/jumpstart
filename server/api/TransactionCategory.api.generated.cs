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
    public class TransactionCategoryController : ControllerBase
    {
        // GET: api/<TransactionCategoryController>
        [HttpGet]
        public IEnumerable<TransactionCategory> Get()
        {
            Console.WriteLine("Processing  GET List" );

            List<TransactionCategory> transactioncategorys = TransactionCategoryLogic.select();

            return transactioncategorys;
        }

        // GET api/<TransactionCategoryController>/5
        [HttpGet("{id}")]
        public TransactionCategory Get(long id)
        {
            Console.WriteLine("Processing TransactionCategory GET ID=" + id.ToString());

            TransactionCategory transactioncategory = TransactionCategoryLogic.get(id);
           
            return transactioncategory;
        }

        // POST api/<TransactionCategoryController>
        [HttpPost]
        public void Post([FromBody] TransactionCategory transactioncategory)
        {
            Console.WriteLine("Processing TransactionCategory POST: " + transactioncategory.ToString()  );
            TransactionCategoryLogic.insert(transactioncategory);
        }

        // PUT api/<TransactionCategoryController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] TransactionCategory transactioncategory)
        {
             Console.WriteLine("Processing TransactionCategory PUT: ID = " + id.ToString() + "\n" + transactioncategory.ToString()  );
            TransactionCategoryLogic.update( id, transactioncategory);
        }

        // DELETE api/<TransactionCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            TransactionCategoryLogic.delete( id );
        }
    }
}

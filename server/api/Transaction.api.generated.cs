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
    public class TransactionController : ControllerBase
    {
        // GET: api/<TransactionController>
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            Console.WriteLine("Processing  GET List" );

            List<Transaction> transactions = TransactionLogic.select();

            return transactions;
        }

        // GET api/<TransactionController>/5
        [HttpGet("{id}")]
        public Transaction Get(long id)
        {
            Console.WriteLine("Processing Transaction GET ID=" + id.ToString());

            Transaction transaction = TransactionLogic.get(id);
           
            return transaction;
        }

        // POST api/<TransactionController>
        [HttpPost]
        public void Post([FromBody] Transaction transaction)
        {
            Console.WriteLine("Processing Transaction POST: " + transaction.ToString()  );
            TransactionLogic.insert(transaction);
        }

        // PUT api/<TransactionController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Transaction transaction)
        {
             Console.WriteLine("Processing Transaction PUT: ID = " + id.ToString() + "\n" + transaction.ToString()  );
            TransactionLogic.update( id, transaction);
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            TransactionLogic.delete( id );
        }
    }
}

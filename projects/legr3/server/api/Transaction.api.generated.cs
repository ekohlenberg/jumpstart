
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
    public class TransactionController : ControllerBase
    {
        // GET: api/<TransactionController>
        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Transaction> transactions = TransactionLogic.Create().select();

            return transactions;
        }

        // GET api/<TransactionController>/5
        [HttpGet("{id}")]
        public Transaction Get(long id)
        {
            //Console.WriteLine($"Processing Transaction GET ID={id}");

            Transaction transaction = TransactionLogic.Create().get(id);

            return transaction;
        }

        // POST api/<TransactionController>
        [HttpPost]
        public void Post([FromBody] Transaction transaction)
        {
            //Console.WriteLine($"Processing Transaction POST: {transaction}");
            TransactionLogic.Create().insert(transaction);
        }

        // PUT api/<TransactionController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Transaction transaction)
        {
            //Console.WriteLine($"Processing Transaction PUT: ID = {id}\n{transaction}");
            TransactionLogic.Create().update(id, transaction);
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            TransactionLogic.Create().delete(id);
        }
    }
}

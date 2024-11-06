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
    public class AccountController : ControllerBase
    {
        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            Console.WriteLine("Processing  GET List" );

            List<Account> accounts = AccountLogic.select();

            return accounts;
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public Account Get(long id)
        {
            Console.WriteLine("Processing Account GET ID=" + id.ToString());

            Account account = AccountLogic.get(id);
           
            return account;
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] Account account)
        {
            Console.WriteLine("Processing Account POST: " + account.ToString()  );
            AccountLogic.insert(account);
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Account account)
        {
             Console.WriteLine("Processing Account PUT: ID = " + id.ToString() + "\n" + account.ToString()  );
            AccountLogic.update( id, account);
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            AccountLogic.delete( id );
        }
    }
}

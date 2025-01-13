
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
    public class AccountController : ControllerBase
    {
        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<Account> Get()
        {
            Console.WriteLine("Processing GET List");

            List<Account> accounts = AccountLogic.Create().select();

            return accounts;
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public Account Get(long id)
        {
            Console.WriteLine($"Processing Account GET ID={id}");

            Account account = AccountLogic.Create().get(id);

            return account;
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] Account account)
        {
            Console.WriteLine($"Processing Account POST: {account}");
            AccountLogic.Create().insert(account);
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Account account)
        {
            Console.WriteLine($"Processing Account PUT: ID = {id}\n{account}");
            AccountLogic.Create().update(id, account);
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            AccountLogic.Create().delete(id);
        }
    }
}

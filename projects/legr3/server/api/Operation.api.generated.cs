
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
    public class OperationController : ControllerBase
    {
        // GET: api/<OperationController>
        [HttpGet]
        public IEnumerable<Operation> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Operation> operations = OperationLogic.Create().select();

            return operations;
        }

        // GET api/<OperationController>/5
        [HttpGet("{id}")]
        public Operation Get(long id)
        {
            //Console.WriteLine($"Processing Operation GET ID={id}");

            Operation operation = OperationLogic.Create().get(id);

            return operation;
        }

        // POST api/<OperationController>
        [HttpPost]
        public void Post([FromBody] Operation operation)
        {
            //Console.WriteLine($"Processing Operation POST: {operation}");
            OperationLogic.Create().insert(operation);
        }

        // PUT api/<OperationController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Operation operation)
        {
            //Console.WriteLine($"Processing Operation PUT: ID = {id}\n{operation}");
            OperationLogic.Create().update(id, operation);
        }

        // DELETE api/<OperationController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            OperationLogic.Create().delete(id);
        }
    }
}

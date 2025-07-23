
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using defarge;

namespace defarge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        // GET: api/<ProcessController>
        [HttpGet]
        public IEnumerable<Process> Get()
        {
            //Console.WriteLine("Processing GET List");

            List<Process> processs = ProcessLogic.Create().select();

            return processs;
        }

        // GET api/<ProcessController>/5
        [HttpGet("{id}")]
        public Process Get(long id)
        {
            //Console.WriteLine($"Processing Process GET ID={id}");

            Process process = ProcessLogic.Create().get(id);

            return process;
        }

        // POST api/<ProcessController>
        [HttpPost]
        public void Post([FromBody] Process process)
        {
            //Console.WriteLine($"Processing Process POST: {process}");
            ProcessLogic.Create().insert(process);
        }

        // PUT api/<ProcessController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Process process)
        {
            //Console.WriteLine($"Processing Process PUT: ID = {id}\n{process}");
            ProcessLogic.Create().update(id, process);
        }

        // DELETE api/<ProcessController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            ProcessLogic.Create().delete(id);
        }
    }
}

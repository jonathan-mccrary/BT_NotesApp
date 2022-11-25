using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BT_NotesApp.API.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        // GET: api/Notes
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Notes/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Notes
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/Notes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Notes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}


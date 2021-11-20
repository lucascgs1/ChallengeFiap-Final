using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChallengeFiap.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EventController : ControllerBase
    {
        // GET: api/<EventController>
        [HttpGet]
        [Route("eventos")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EventController>/5
        [HttpGet]
        [Route("evento/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EventController>
        [HttpPost]
        [Route("evento/criar")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EventController>/5
        [HttpPost]
        [Route("evento/editar")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventController>/5
        [HttpDelete("evento/remover/{id}")]
        public void Delete(int id)
        {
        }
    }
}

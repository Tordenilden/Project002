using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project002.API.Controllers
{
    [Route("api/[controller]")] // our URL
    [ApiController] // this we will take in another afsnit
    public class SamuraiController : ControllerBase
    {
        private readonly ISamuraiRepository repo;

        public SamuraiController(ISamuraiRepository repo)
        {
            this.repo = repo;
        }




        // GET: api/<SamuraiController>
        [HttpGet] // This is a DataAnnotation / Attribute
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SamuraiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SamuraiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SamuraiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SamuraiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

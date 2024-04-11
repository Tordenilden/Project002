using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Interfaces;
using Project002.Repository.Models;

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





        [HttpGet] // This is a DataAnnotation / Attribute
        public IEnumerable<Samurai> GetAll()
        {
            // If I want to DEBUG!!
            var result = repo.GetAll();
            return result;
            
        }



        // Create
        [HttpPost]
        public void Create(Samurai samurai)
        {
            //Samurai s = new Samurai(); // blablabla
            repo.Create(samurai);
            
        }






        // GET api/<SamuraiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

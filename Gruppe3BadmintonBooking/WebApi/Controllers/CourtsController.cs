using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtsController : ControllerBase
    {
        private readonly IDataAccess<Court> _courtDb;

        public CourtsController(IDataAccess<Court> courtDb)
        {
            _courtDb = courtDb;
        }


    
        // GET: api/<CourtsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CourtsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CourtsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CourtsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CourtsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

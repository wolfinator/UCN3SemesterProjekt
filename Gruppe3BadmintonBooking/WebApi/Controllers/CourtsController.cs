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
        private readonly IDaoCourt _courtDb;
        private readonly ILogger<CourtsController> _logger;


        public CourtsController(ILogger<CourtsController> logger, IDaoCourt courtDb)
        {
            _logger = logger;
            _courtDb = courtDb;
        }


    
        // GET: api/<CourtsController>
        [HttpGet]
        public IEnumerable<Court> Get()
        {
            return _courtDb.GetAll();
        }

        // GET api/<CourtsController>/5
        [HttpGet("{id}")]
        public Court Get(int id)
        {
            return _courtDb.GetById(id);
        }

        /*
        // POST api/<CourtsController>
        [HttpPost]
        public void Post([FromBody] Court court)
        {
            try
            {
                _courtDb.Create(court);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to post court in database: \n{ex.Message}");

            }
          
        }

        // PUT api/<CourtsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Court court)
        {
            try
            {
                _courtDb.Update(court);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to put court in database: \n{ex.Message}");
            }
        }

        // DELETE api/<CourtsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _courtDb.DeleteById(id);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to delete court in database: \n{ex.Message}");

            }
        }
        */
    }
}

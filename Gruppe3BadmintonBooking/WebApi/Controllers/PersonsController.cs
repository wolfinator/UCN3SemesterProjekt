using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {

        private readonly ILogger<PersonsController> _logger;
        private readonly IDataAccess<Customer> _personDb;

        public PersonsController(ILogger<PersonsController> logger, IDataAccess<Customer> personDb)
        {
            _logger = logger;
            _personDb = personDb;
        }

        [HttpGet]
        public IEnumerable<Customer> GetAllPersons()
        {
            IEnumerable<Customer> persons = null;
            try
            {
                persons = _personDb.GetAll();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to get persons from database:\n{ex.Message}");
            }
            return persons;
        }
        [HttpGet("{id}")]
        public ActionResult<Customer> GetPerson(int id)
        {
            Customer person = null;
            try
            {
                person = _personDb.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to get person with id {id} from database:\n{ex.Message}");
            }
            if (person is null) return NotFound();
            return person;
        }

        [HttpPost]
        public ActionResult<Customer> PostPerson(Customer person)
        {
            bool created = false;
            person = new Guest()
            {
                firstName = person.firstName,
                lastName = person.lastName,
                email = person.email,
                phoneNo = person.phoneNo,
                street = person.street,
                houseNo = person.houseNo,
                zipcode = person.zipcode
            }; // makeshift solution for task under create ASP.NET web api: make post requests with subclasses
            try
            {
                created = _personDb.Create(person);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to create person in database:\n{ex.Message}");
            }
            if (created) return CreatedAtAction("PostPerson", person);
            return person;
        }

        [HttpPut("{id}")]
        public IActionResult PutPerson(int id, Customer updatedPerson)
        {
            bool updated = false;
            updatedPerson = new Guest()
            {
                id = updatedPerson.id,
                firstName = updatedPerson.firstName,
                lastName = updatedPerson.lastName,
                email = updatedPerson.email,
                phoneNo = updatedPerson.phoneNo,
                street = updatedPerson.street,
                houseNo = updatedPerson.houseNo,
                zipcode = updatedPerson.zipcode
            }; // makeshift solution for task under create ASP.NET web api: make post requests with subclasses
            try
            {
                updated = _personDb.Update(updatedPerson);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to update person (id: {id}) in database:\n{ex.Message}");
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            bool deleted = false;
            try
            {
                deleted = _personDb.DeleteById(id);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to delete person (id: {id}) in database:\n{ex.Message}");
            }
            return NoContent();
        }
    }
}
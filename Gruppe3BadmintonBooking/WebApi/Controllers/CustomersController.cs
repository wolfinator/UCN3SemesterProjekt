using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {

        private readonly ILogger<CustomersController> _logger;
        private readonly IDaoCustomer _customerDb;

        public CustomersController(ILogger<CustomersController> logger, IDaoCustomer personDb)
        {
            _logger = logger;
            _customerDb = personDb;
        }

        [HttpGet]
        public IEnumerable<Customer> GetAllCustomers()
        {
            IEnumerable<Customer> customers = null;
            try
            {
                customers = _customerDb.GetAll();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to get customer from database:\n{ex.Message}");
            }
            return customers;
        }
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            Customer customer = null;
            try
            {
                customer = _customerDb.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to get customer with id {id} from database:\n{ex.Message}");
            }
            if (customer is null) return NotFound();
            return customer;
        }

        [HttpPost]
        public ActionResult<Customer> PostCustomer(Customer customer)
        {
            int customerId = -1;
            try
            {
                customerId = _customerDb.Create(customer);
                customer.id = customerId;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to create customer in database:\n{ex.Message}");
            }
            return customer;
        }

        [HttpPut("{id}")]
        public IActionResult PutPerson(int id, Customer updatedCustomer)
        {
            bool updated = false;
            try
            {
                updated = _customerDb.Update(updatedCustomer);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to update customer (id: {id}) in database:\n{ex.Message}");
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            bool deleted = false;
            try
            {
                deleted = _customerDb.DeleteById(id);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to delete customer (id: {id}) in database:\n{ex.Message}");
            }
            return NoContent();
        }
    }
}
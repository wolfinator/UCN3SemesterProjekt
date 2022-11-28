using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ILogger<ReservationsController> _logger;
        private readonly IDaoReservation _reservationDb;

        public ReservationsController(ILogger<ReservationsController> logger, IDaoReservation reservationDb)
        {
            _logger = logger;
            _reservationDb = reservationDb;
        }

        // GET: api/<ReservationController>
        [HttpGet]
        public IEnumerable<Reservation> Get()
        {
            IEnumerable<Reservation> reservations = null;
            try
            {
                reservations = _reservationDb.GetAll();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to get reservations in database:\n{ex.Message}");
            }
            return reservations;
        }

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public Reservation? Get(int id)
        {
            Reservation reservation = null;
            try
            {
                reservation = _reservationDb.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to get reservations in database:\n{ex.Message}");
            }
            return reservation;
        }

        // POST api/<ReservationController>
        [HttpPost]
        public void Post([FromBody] Reservation reservation)
        {
            try
            {
                _reservationDb.Create(reservation);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to create reservation in database:\n{ex.Message}");
            }
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Reservation reservation)
        {
            try
            {
                _reservationDb.Update(reservation);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to create reservation in database:\n{ex.Message}");
            }
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _reservationDb.DeleteById(id);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to create reservation in database:\n{ex.Message}");
                throw;
            }
        }
    }
}

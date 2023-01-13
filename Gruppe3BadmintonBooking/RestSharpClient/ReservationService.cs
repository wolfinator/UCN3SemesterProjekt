using Model;
using RestSharp;
using RestSharpClient.Interfaces;
using System.Text.Json;

namespace RestSharpClient
{
    public class ReservationService : IReservationService
    {

        private RestSharp.RestClient _restClient;

        public ReservationService()
        {
            _restClient = new RestSharp.RestClient($"{RestClientInfo.IpAddress}/api/Reservations");
        }

        // Metoden der forespørger API om at lave en reservation
        public int Create(Reservation reservation)
        {
            // Lav requesten
            var request = new RestRequest();
            // Sæt reservation objektet med som body
            request.AddBody(reservation);
            // Gem responsen fra API'en i et objekt
            var response = _restClient.Post(request);
            // Hent det JSON API'en sendte fra responsen og lav det til et Reservations objekt
            var createdReservation = JsonSerializer.Deserialize<Reservation>(response.Content);
            // Hvis den ikke er null returnér dens ID
            if (createdReservation != null) return createdReservation.id;
            // Ellers returnér -1 for at vise der gik noget galt
            return -1;
        }

        public bool DeleteById(int id)
        {
            // Sæt parameteren id in i URL'en så i stedet for den spørger /api/reservations
            // så vil den spørge /api/reservation/id
            var request = new RestRequest($"{id}");
            var response = _restClient.Delete(request);
            return response.IsSuccessStatusCode;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _restClient.Get<IEnumerable<Reservation>>(new RestRequest());
        }

        public IEnumerable<Reservation> GetAllByPhoneNo(string phoneNo)
        {
            return _restClient.Get<IEnumerable<Reservation>>(new RestRequest($"FilterByPhoneNo/{phoneNo}"));
        }

        public List<object[]> GetAvailableTimes(string date)
        {
            var list = _restClient.Get<List<object[]>>(new RestRequest($"AvailableTimes/{date}"));
            list.ForEach(values => values[1] = DateTime.Parse(date) + ((JsonElement)values[1]).Deserialize<TimeSpan>());
            return list;
        }

        public Reservation GetById(int id)
        {
            return _restClient.Get<Reservation>(new RestRequest($"{id}"));
        }

        public bool Update(Reservation reservation)
        {
            var request = new RestRequest($"{reservation.id}");
            request.AddBody(reservation);
            var response = _restClient.Put(request);
            return response.IsSuccessStatusCode;
        }
    }
}
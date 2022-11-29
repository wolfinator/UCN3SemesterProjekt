using Model;
using RestSharp;
using RestSharpClient.Interfaces;

namespace RestSharpClient
{
    public class ReservationService : IReservationService
    {

        private RestSharp.RestClient _restClient;

        public ReservationService()
        {
            _restClient = new RestSharp.RestClient($"{RestClientInfo.IpAddress}/api/Reservations");
        }

        public bool Create(Reservation reservation)
        {
            var request = new RestRequest();
            var response = _restClient.Post(new RestRequest().AddJsonBody(reservation));
            return response.IsSuccessStatusCode;
        }

        public bool DeleteById(int id)
        {
            var request = new RestRequest($"{id}");
            var response = _restClient.Delete(request);
            return response.IsSuccessStatusCode;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _restClient.Get<IEnumerable<Reservation>>(new RestRequest());
        }

        public List<object[]> GetAvailableTimes(string date)
        {
            return _restClient.Get<List<object[]>>(new RestRequest($"AvailableTimes/{date}"));
        }

        public Reservation GetById(int id)
        {
            return _restClient.Get<Reservation>(new RestRequest($"{id}"));
        }

        public bool Update(Reservation reservation)
        {
            var request = new RestRequest($"{reservation.Id}");
            var response = _restClient.Put(request);
            return response.IsSuccessStatusCode;
        }
    }
}
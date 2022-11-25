using Model;
using RestSharp;

namespace RestSharpClient
{
    public class ReservationService : IServiceDatabase<Reservation>
    {

        private RestSharp.RestClient _restClient;

        public ReservationService()
        {
            _restClient = new RestSharp.RestClient("https://localhost:44325/api/reservations");
        }

        public bool Create(Reservation entity)
        {
            _restClient.Post<Reservation>(new RestRequest());
          
        }

        public bool DeleteById(int id)
        {
            _restClient.Delete<Reservation>(new RestRequest());
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _restClient.Get<IEnumerable<Reservation>>(new RestRequest());

        }

        public Reservation GetById(int id)
        {
            return _restClient.Get<Reservation>(new RestRequest());
        }

        public bool Update(Reservation entity)
        {
            _restClient.Put<Reservation>(new RestRequest());
        }
    }
}
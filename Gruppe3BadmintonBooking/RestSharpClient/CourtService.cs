using Model;
using RestSharp;

namespace RestSharpClient
{
    public class CourtService : IServiceDatabase<Court>
    {

        private RestSharp.RestClient _restClient;

        public CourtService()
        {
            _restClient = new RestSharp.RestClient("https://localhost:44325/api/courts");
        }

        public bool Create(Court entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Court> GetAll()
        {
            return _restClient.Get<IEnumerable<Court>>(new RestRequest());

          
        }

        public Court GetById(int id)
        {
            return _restClient.Get<Court>(new RestRequest());
        }

        public bool Update(Court entity)
        {
            throw new NotImplementedException();
        }
    }
}
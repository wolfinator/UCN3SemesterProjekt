using Model;
using RestSharp;
using RestSharpClient.Interfaces;

namespace RestSharpClient
{
    public class CourtService : ICourtService
    {

        private RestSharp.RestClient _restClient;

        public CourtService()
        {
            _restClient = new RestSharp.RestClient($"{RestClientInfo.IpAddress}/api/courts");
        }

        public int Create(Court entity)
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
            return _restClient.Get<Court>(new RestRequest($"{id}"));
        }

        public bool Update(Court entity)
        {
            throw new NotImplementedException();
        }
    }
}
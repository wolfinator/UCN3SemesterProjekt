using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Model;

namespace RestSharpClient
{
    public class PersonService : IServiceDatabase<Customer>
    {
        private RestSharp.RestClient _restClient;
        
        public PersonService()
        {
            _restClient = new RestSharp.RestClient("https://localhost:44325/api/courts");
        }

        public bool Create(Customer entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            return _restClient.Delete(new RestRequest(id.ToString())).IsSuccessful;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _restClient.Get<IEnumerable<Customer>>(new RestRequest());
        }

        public Customer GetById(int id)
        {
            return _restClient.Get<Customer>(new RestRequest());
        }

        public bool Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
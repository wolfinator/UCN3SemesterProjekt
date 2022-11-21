using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Model;

namespace RestSharpClient
{
    public class PersonService : IServiceDatabase<Person>
    {
        private RestSharp.RestClient _restClient;
        
        public PersonService()
        {
            _restClient = new RestSharp.RestClient("https://localhost:44325/api/courts");
        }

        public bool Create(Person entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            return _restClient.Delete(new RestRequest(id.ToString())).IsSuccessful;
        }

        public IEnumerable<Person> GetAll()
        {
            return _restClient.Get<IEnumerable<Person>>(new RestRequest());
        }

        public Person GetById(int id)
        {
            return _restClient.Get<Person>(new RestRequest());
        }

        public bool Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
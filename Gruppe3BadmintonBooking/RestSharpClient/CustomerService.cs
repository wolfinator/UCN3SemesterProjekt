using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Model;
using RestSharpClient.Interfaces;
using System.Text.Json;

namespace RestSharpClient
{
    public class CustomerService : ICustomerService
    {
        private RestSharp.RestClient _restClient;
        
        public CustomerService()
        {
            _restClient = new RestSharp.RestClient($"{RestClientInfo.IpAddress}/api/Customers");
        }

        public int Create(Customer customer)
        {
            var request = new RestRequest();
            request.AddJsonBody(customer);
            var response = _restClient.Post(request);
            var createdCustomer = JsonSerializer.Deserialize<Customer>(response.Content);
            if(createdCustomer != null) return createdCustomer.id;
            return -1;
        }

        public bool DeleteById(int id)
        {
            var request = new RestRequest($"{id}");
            var response = _restClient.Delete(request);
            return response.IsSuccessStatusCode;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _restClient.Get<IEnumerable<Customer>>(new RestRequest());
        }

        public Customer GetById(int id)
        {
            return _restClient.Get<Customer>(new RestRequest($"{id}"));
        }

        public bool Update(Customer customer)
        {
            var request = new RestRequest();
            request.AddJsonBody(customer);
            var response = _restClient.Put(request);

            return response.IsSuccessStatusCode;
        }
    }
}
using Model;
using RestSharp;
using RestSharpClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestSharpClient
{
    public class InvoiceService : IInvoiceService
    {
        private RestSharp.RestClient _restClient;

        public InvoiceService()
        {
            _restClient = new($"{RestClientInfo.IpAddress}/api/invoices");
        }
        public int Create(Invoice invoice)
        {
            var request = new RestRequest();
            request.AddJsonBody(invoice);
            var response = _restClient.Post(request);
            var createdInvoice = JsonSerializer.Deserialize<Invoice>(response.Content);
            if (createdInvoice != null) return createdInvoice.id;
            return -1;
        }

        public bool DeleteById(int id)
        {
            var request = new RestRequest($"{id}");
            var response = _restClient.Delete(request);
            
            return response.IsSuccessStatusCode;
        }

        public IEnumerable<Invoice> GetAll()
        {
            return _restClient.Get<IEnumerable<Invoice>>(new RestRequest());
        }

        public Invoice GetById(int id)
        {
            return _restClient.Get<Invoice>(new RestRequest($"{id}"));
        }

        public bool Update(Invoice updatedInvoice)
        {
            var request = new RestRequest();
            request.AddJsonBody(updatedInvoice);
            var response = _restClient.Post(request);
            return response.IsSuccessStatusCode;
        }
    }
}

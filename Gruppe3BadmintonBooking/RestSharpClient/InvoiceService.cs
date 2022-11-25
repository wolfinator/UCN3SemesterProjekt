using Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpClient
{
    public class InvoiceService : IServiceDatabase<Invoice>
    {
        private RestSharp.RestClient _restClient;

        public InvoiceService()
        {
            _restClient = new("https://localhost:7077/api/invoices");
        }
        public bool Create(Invoice entity)
        {
            bool created = false;
            created = _restClient.Post<Invoice>(new RestRequest().AddJsonBody(entity)) != null;
            return created;
        }

        public bool DeleteById(int id)
        {
            bool deleted = false;
            deleted = _restClient.Delete(new RestRequest($"{id}")).IsSuccessful;
            return deleted;
        }

        public IEnumerable<Invoice> GetAll()
        {
            return _restClient.Get<IEnumerable<Invoice>>(new RestRequest());
        }

        public Invoice GetById(int id)
        {
            return _restClient.Get<Invoice>(new RestRequest());
        }

        public bool Update(Invoice entity)
        {
            bool updated = false;
            updated = _restClient.Put(new RestRequest().AddJsonBody(entity)).IsSuccessful;
            return updated;
        }
    }
}

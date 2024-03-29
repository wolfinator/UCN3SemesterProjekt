﻿using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly ILogger<InvoicesController> _logger;
        private readonly IDaoInvoice _invoiceDb;

        public InvoicesController(ILogger<InvoicesController> logger, IDaoInvoice invoiceDb)
        {
            _logger = logger;
            _invoiceDb = invoiceDb;
        }
        // GET: api/<InvoicesController>
        [HttpGet]
        public IEnumerable<Invoice> Get()
        {
            IEnumerable<Invoice> invoices = null;
            try
            {
                invoices = _invoiceDb.GetAll();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to get invoices in database:\n{ex.Message}");
            }
            return invoices;
        }

        // GET api/<InvoicesController>/5
        [HttpGet("{id}")]
        public Invoice Get(int id)
        {
            Invoice invoice = null;
            try
            {
                invoice = _invoiceDb.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to get invoice with id {id} in database:\n{ex.Message}");
            }
            return invoice;
        }


        // POST api/<InvoicesController>
        [HttpPost]
        public Invoice Post([FromBody] Invoice invoice)
        {
            try
            {
                invoice.id = _invoiceDb.Create(invoice);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Failed to post invoice in database:\n{ex.Message}");
            }
            return invoice;
        }
        /*
        // PUT api/<InvoicesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InvoicesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}

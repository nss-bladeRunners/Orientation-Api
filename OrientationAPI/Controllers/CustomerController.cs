using OrientationAPI.Models;
using OrientationAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrientationAPI.Controllers
{
	[RoutePrefix("api/customers")]
	public class CustomerController : ApiController
	{
		[Route(""), HttpPost]
		public HttpResponseMessage AddCustomer(CustomerDto customer)
		{
			var repository = new CustomerRepository();
			var dbResult = repository.Create(customer);
			return Request.CreateAddRecordResponse(dbResult); 
		}

	    [HttpGet, Route("")]
        public HttpResponseMessage ListCustomers()
        {
            var repo = new CustomerRepository();
            var dbResults = repo.GetAllActive();
            return Request.CreateListRecordsResponse(dbResults);
        }

		[Route("{customerId}"), HttpPatch]
		public HttpResponseMessage UpdateCustomer(Customer customer, int customerId)
		{
			customer.CustomerId = customerId;
			var repository = new CustomerRepository();
			var dbResults = repository.Update(customer);
			return Request.CreateUpdateRecordResponse(dbResults);
		}

		[HttpPatch, Route("{customerId}/deactivate")]
		public HttpResponseMessage DeactivateCustomer(int customerId)
		{
			var repo = new CustomerRepository();
            var dbResults = repo.Deactivate(customerId);
            return Request.CreateUpdateRecordResponse(dbResults);
		}

	}
}

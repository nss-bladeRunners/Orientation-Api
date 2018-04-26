using OrientationAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrientationAPI.Controllers
{
	[RoutePrefix("api/employees")]
	public class EmployeesController : ApiController
	{
		[Route(""), HttpGet]
		public HttpResponseMessage ListEmployees()
		{
			var repo = new EmployeeRepository();
			var result = repo.GetAll();
			return Request.CreateListRecordsResponse(result);
		}

		[Route("create"), HttpPost]
		public HttpResponseMessage AddEmployee(EmployeeDto employee)
		{
			var repo = new EmployeeRepository();
			var result = repo.Create(employee);

			return Request.CreateAddRecordResponse(result);
		}

	}
}
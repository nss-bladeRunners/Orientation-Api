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

		[Route("employee-details/{employeeId}"), HttpGet]
		public HttpResponseMessage GetEmployeeDetails(int employeeId)
		{
			var repo = new EmployeeRepository();
			var result = repo.GetEmployee(employeeId);
			return Request.CreateResponse(result);
		}

		[Route("employee-details/{employeeId}/training"), HttpGet]
		public HttpResponseMessage GetEmployeeTraining(int employeeId)
		{
			var repo = new EmployeeRepository();
			var result = repo.GetTraining(employeeId);
			return Request.CreateListRecordsResponse(result);
		}

		[Route("{employeeId}"), HttpPut]
		public HttpResponseMessage UpdateEmployee(Employee employee, int employeeId)
		{
			employee.EmployeeId = employeeId;
			var repo = new EmployeeRepository();
			var result = repo.UpdateEmployee(employee);
			return Request.CreateUpdateRecordResponse(result);
		}

		[Route("{employeeId}/computer/{computerId}"),HttpPost]
		public HttpResponseMessage UpdateEmployeeComputer(int employeeId, int computerId)
		{
			var repo = new EmployeeRepository();
			var result = repo.UpdateComputer(employeeId, computerId);
			return Request.CreateAddRecordResponse(result);
		}

		[Route("{employeeId}/deleteTraiking/{trainingId}"), HttpDelete]
		public HttpResponseMessage DeleteEmployeeTraining(Employee employee, int employeeId)
		{
			throw new NotImplementedException(); 
		}

	}
}
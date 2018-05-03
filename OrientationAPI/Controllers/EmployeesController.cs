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

        [Route("{employeeId}/availableTrainings"), HttpGet]
        public HttpResponseMessage GetAvailableTrainings(int employeeId)
        {
            var repo = new EmployeeRepository();
            var result = repo.GetAvailableTrainings(employeeId);
            return Request.CreateListRecordsResponse(result);
        }

        [Route("{employeeId}/addTraining/{trainingId}"), HttpPost]
        public HttpResponseMessage CreateEmployeeTraining(int employeeId, int trainingId)
        {
            var repo = new EmployeeRepository();
            var result = repo.CreateEmployeeTraining(employeeId, trainingId);
            return Request.CreateAddRecordResponse(result);
        }
    }
}
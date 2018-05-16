using OrientationAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace OrientationAPI.Controllers 
{
    [RoutePrefix("api/employeeComputers")]
    public class EmployeeComputerController : ApiController
    {

        [Route("{computerId}"), HttpGet]
        public HttpResponseMessage GetEmployeeComputersByComputerId(int computerId)
        {
            var repo = new ComputerRepository();
            var result = repo.GetAllByEmployeeComputersByComputerId(computerId);
            return Request.CreateListRecordsResponse(result);
        }

    }
}
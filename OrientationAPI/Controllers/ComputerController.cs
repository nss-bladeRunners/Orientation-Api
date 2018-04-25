using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrientationAPI.Models;
using OrientationAPI.Services;


namespace OrientationAPI.Controllers
{
    [RoutePrefix("api/computers")]
    public class ComputerController : ApiController
    {
        [Route(""), HttpGet]
        public HttpResponseMessage ListComputers()
        {
            var repo = new ComputerRepository();
            List<Computer> computers = repo.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, computers);
        }

        [Route(""), HttpPost]
        public HttpResponseMessage AddComputer(Computer computer)
        {
            var repository = new ComputerRepository();
            var result = repository.Create(computer);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Customer could not be created, please try again later.");
        }

        [Route("{computerId}"), HttpPatch]
        public HttpResponseMessage UpdateCustomer(Computer computer, int computerId)
        {
            computer.ComputerId = computerId;
            var repository = new ComputerRepository();
            var result = repository.Update(computer);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not update computer information, please try again later.");
        }
    }
}

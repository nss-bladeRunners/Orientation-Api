using OrientationAPI.Models;
using OrientationAPI.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrientationAPI.Controllers
{
    [RoutePrefix("api/departments")]
    public class DepartmentController : ApiController
    {
       [HttpGet, Route]
       public HttpResponseMessage ListDepartment()
       {
            var repository = new DepartmentRepository();
            var result = repository.ListDepartment();
            return Request.CreateListRecordsResponse(result);
       }

        [HttpGet, Route("{departmentId}/employees")]
        public HttpResponseMessage GetEmployeesByDepartmentId(int departmentId)
        {
            var repo = new DepartmentRepository();
            var dbResults = repo.GetEmployeesByDepartmentId(departmentId);
            return Request.CreateResponse(HttpStatusCode.OK, dbResults);
        }

        [HttpGet, Route("{departmentId}")]
        public HttpResponseMessage GetDepartmentById(int departmentId)
        {
            var repo = new DepartmentRepository();
            var dbResults = repo.GetDepartmentById(departmentId);
            return Request.CreateResponse(HttpStatusCode.OK, dbResults);
        }

        [Route, HttpPost]
        public HttpResponseMessage AddNewDepartment(DepartmentDto department)
        {
            var repository = new DepartmentRepository();
            var result = repository.AddNewDepartment(department);
            return Request.CreateAddRecordResponse(result);
        }
    }
}
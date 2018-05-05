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
    [RoutePrefix("api/training")]
    public class TrainingController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage Create(TrainingProgram dto)
        {
            var repo = new TrainingRepository();
            var dbResults = repo.Create(dto);
            return Request.CreateAddRecordResponse(dbResults);
        }

        [Route, HttpGet]
        public HttpResponseMessage GetAllUpcoming()
        {
            var repo = new TrainingRepository();
            var dbResults = repo.GetAllUpcoming();
            return Request.CreateListRecordsResponse(dbResults);
        }

        [HttpGet, Route("{trainingId}")] 
        public HttpResponseMessage GetTrainingProgram(int trainingId)
        {
            var repo = new TrainingRepository();
            var dbResults = repo.GetTrainingProgramById(trainingId);
            return Request.CreateListRecordsResponse(dbResults);
        }

        [Route, HttpPut]
        public HttpResponseMessage Update(TrainingProgram dto)
        {
            var repo = new TrainingRepository();
            var dbResult = repo.Update(dto);
            return Request.CreateUpdateRecordResponse(dbResult);
        }

        [HttpDelete, Route("{trainingId}")]
        public HttpResponseMessage Delete(int trainingId)
        {
            var repo = new TrainingRepository();
            var dbResult = repo.Delete(trainingId);
            return Request.CreateUpdateRecordResponse(dbResult);
        }

	}

}

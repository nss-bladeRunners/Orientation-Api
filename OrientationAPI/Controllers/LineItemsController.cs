using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrientationAPI.Models;
using OrientationAPI.Services;

namespace OrientationAPI.Controllers
{
    [RoutePrefix("api/lineitems")]
    public class LineItemsController : ApiController
    {
        [HttpPost, Route("")]
        public HttpResponseMessage AddLineItem(LineItemDto lineItem)
        {
            var dbResult = OrderPlacement.AddLineItem(lineItem); 


            return Request.CreateAddRecordResponse(dbResult);
        }
    }
}

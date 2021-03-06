﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrientationAPI.Models;
using OrientationAPI.Services;

namespace OrientationAPI.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController :
        ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage CreateOrder(OrderDto createOrder)
        {
            var repository = new OrderRepository();
            var result = repository.Create(createOrder.CustomerId);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not create order");
        }

        [Route("{orderId}/close"), HttpPatch]
        public HttpResponseMessage CloseOrder(int  orderId)
        {
            var repository = new OrderRepository();

            var result = repository.CloseOrder(orderId);

            return Request.CreateResponse(HttpStatusCode.Created);

        }

        [HttpPatch, Route("{orderId}/pay")]
        public HttpResponseMessage Pay(int orderId)
        {
            var result = OrderPayment.PayForOrder(orderId);
            return Request.CreateUpdateRecordResponse(result); 
        }

        [HttpGet, Route("outstanding")]
        public HttpResponseMessage GetOutstanding()
        {
            var repo = new OrderRepository();
            var orders = repo.SelectOutstandingOrders(30);
            return Request.CreateListRecordsResponse(orders);
        }
    }
}
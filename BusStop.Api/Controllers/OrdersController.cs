using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusStop.Contracts;
using NServiceBus;
using System.Web;

namespace BusStop.Api.Controllers
{
    public class OrdersController : ApiController
    {
      
        public Guid Get()
        {
            var order = new PlaceOrder
                {
                    OrderId = Guid.NewGuid(),
                    ProductId = Guid.NewGuid(),
                    CustomerId = Guid.NewGuid(),
                };

            WebApiApplication.Bus.Send(order);

            return order.OrderId;
        }
    }
}

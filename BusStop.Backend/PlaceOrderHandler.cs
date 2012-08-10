using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using BusStop.Contracts;
using Raven.Client.Document;
using Raven.Client;

namespace BusStop.Backend
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public IDocumentSession Session { get; set; }

        public void Handle(PlaceOrder message)
        {
            Session.Store(new Order
            {
                OrderId = message.OrderId
            });

            Console.WriteLine("Order received " + message.OrderId);
        }
    }

    public class Order
    {
        public Guid OrderId { get; set; }
    }
}

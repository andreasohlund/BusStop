using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using Raven.Client.Document;
using Raven.Client;
using BusStop.Sales.InternalMessages;
using BusStop.Sales.Contracts;

namespace BusStop.Sales
{
    public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
    {
        public IDocumentSession Session { get; set; }
        public IBus Bus { get; set; }

        public void Handle(PlaceOrder message)
        {
            Session.Store(new Order
            {
                OrderId = message.OrderId
            });

            Bus.Publish(new OrderAccepted
            {
                CustomerId = message.CustomerId,
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

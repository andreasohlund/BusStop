using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using BusStop.Contracts;
using Raven.Client.Document;
using Raven.Client;
using BusStop.Billing.Contracts;

namespace BusStop.Backend
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

            Bus.Send(new ChargeCreditCard
            {
                CustomerId = message.CustomerId,
                Amount = 100
            });

            Console.WriteLine("Order received " + message.OrderId);
        }
    }

    public class Order
    {
        public Guid OrderId { get; set; }
    }
}

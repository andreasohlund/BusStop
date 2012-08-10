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
    public class PlaceOrderHandler:IHandleMessages<PlaceOrder>
    {
        public IDocumentStore Store { get; set; }

        public void Handle(PlaceOrder message)
        {
            using (var session = Store.OpenSession())
            {
                session.Store(new Order
                {
                    OrderId = message.OrderId
                });

                session.SaveChanges();
            }


            Console.WriteLine("Order received " + message.OrderId);
        }
    }

    public class Order
    {
        public Guid OrderId { get; set; }
    }
}

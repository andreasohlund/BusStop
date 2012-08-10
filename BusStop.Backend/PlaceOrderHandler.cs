using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using BusStop.Contracts;
using Raven.Client.Document;

namespace BusStop.Backend
{
    public class PlaceOrderHandler:IHandleMessages<PlaceOrder>
    {
        public void Handle(PlaceOrder message)
        {
            var store = new DocumentStore 
            { 
                Url = "http://localhost:8080"
            };

            store.Initialize();
            store.JsonRequestFactory.DisableRequestCompression = true;

            using (var session = store.OpenSession())
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

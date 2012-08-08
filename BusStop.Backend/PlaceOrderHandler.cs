using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using BusStop.Contracts;

namespace BusStop.Backend
{
    public class PlaceOrderHandler:IHandleMessages<PlaceOrder>
    {
        public void Handle(PlaceOrder message)
        {
            Console.WriteLine("Order received " + message.OrderId);
        }
    }
}

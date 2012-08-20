using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusStop.Sales.Contracts;
using NServiceBus;
using BusStop.Billing.InternalMessages;

namespace BusStop.Billing
{
    class OrderAcceptedHandler:IHandleMessages<OrderAccepted>
    {
        public IBus Bus { get; set; }
        public void Handle(OrderAccepted message)
        {
            Console.WriteLine("Order accepted: " + message.OrderId);

            Bus.Send(new ChargeCreditCard
            {
                CustomerId = message.CustomerId,
                Amount = 100
            });
        }
    }
}

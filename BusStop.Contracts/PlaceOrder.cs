using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NServiceBus;

namespace BusStop.Contracts
{
    public class PlaceOrder : IMessage
    {
        public Guid OrderId { get; set; }
        
        public Guid ProductId { get; set; }

        public Guid CustomerId { get; set; }
    }
}
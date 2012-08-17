using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NServiceBus;

namespace BusStop.Sales.InternalMessages
{
    public class PlaceOrder : IMessage
    {
        public Guid OrderId { get; set; }
        
        public Guid ProductId { get; set; }

        public Guid CustomerId { get; set; }
    }

    public class CancelOrder : IMessage
    {
        public Guid OrderId { get; set; }
    }

    public enum CommandStatus
    { 
        Failed = 0,
        Success = 1
    }
}
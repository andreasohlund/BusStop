using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace BusStop.Sales.Contracts
{
    public class OrderAccepted:IMessage
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace BusStop.Billing.InternalMessages
{
    public class ChargeCreditCard:IMessage
    {
        public Guid CustomerId { get; set; }
        public double Amount { get; set; }
    }

    public class CreditCardCharged : IMessage
    {
        public Guid CustomerId { get; set; }
        public string Receipt{ get; set; }
    }
}

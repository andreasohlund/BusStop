using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusStop.Sales.Contracts
{
    public class OrderAccepted
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
    }
}

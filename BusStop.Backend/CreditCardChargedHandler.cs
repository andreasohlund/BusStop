using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusStop.Billing.Contracts;
using NServiceBus;

namespace BusStop.Backend
{
    class CreditCardChargedHandler:IHandleMessages<CreditCardCharged>
    {
        public void Handle(CreditCardCharged message)
        {
            //todo store in raven
            Console.WriteLine("Customer " + message.CustomerId + " charged, receipt: " + message.Receipt);
        }
    }
}

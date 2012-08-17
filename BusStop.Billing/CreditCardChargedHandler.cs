using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using BusStop.Billing.InternalMessages;

namespace BusStop.Billing
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

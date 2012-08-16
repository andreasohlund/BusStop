using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using BusStop.Authentication;

namespace BusStop.Billing.CreditCardGateway
{
    public class EndpointConfig:IConfigureThisEndpoint,AsA_Server,ISpecifyMessageHandlerOrdering
    {
        public void SpecifyOrder(NServiceBus.Order order)
        {
            order.SpecifyFirst<AuthenticationHandler>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using BusStop.Authentication;
using BusStop.Config;

namespace BusStop.Backend
{
    public class EndpointConfig:IConfigureThisEndpoint,AsA_Publisher,ISpecifyMessageHandlerOrdering,IWantCustomInitialization
    {
        public void SpecifyOrder(NServiceBus.Order order)
        {
            order.Specify<First<AuthenticationHandler>>();
        }

        public void Init()
        {
            Configure.With()
                .MyMessageConventions();
        }
    }
}

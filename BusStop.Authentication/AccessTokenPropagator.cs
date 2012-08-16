using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus.MessageMutator;
using NServiceBus;
using NServiceBus.Config;

namespace BusStop.Authentication
{
    public class AccessTokenPropagator:IMutateOutgoingTransportMessages, INeedInitialization
    {
        public IBus Bus { get; set; }
        public void MutateOutgoing(object[] messages, NServiceBus.Unicast.Transport.TransportMessage transportMessage)
        {
            if (Bus.CurrentMessageContext == null || !Bus.CurrentMessageContext.Headers.ContainsKey("access_token"))
                return;

            transportMessage.Headers["access_token"] = Bus.CurrentMessageContext.Headers["access_token"];
        }

        public void Init()
        {
            Configure.Instance.Configurer.ConfigureComponent<AccessTokenPropagator>(DependencyLifecycle.InstancePerCall);
        }
    }
}

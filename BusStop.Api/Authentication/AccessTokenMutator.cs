using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NServiceBus.MessageMutator;
using NServiceBus.Config;
using NServiceBus;

namespace BusStop.Api.Authentication
{
    public class AccessTokenMutator:IMutateOutgoingTransportMessages,INeedInitialization
    {
        public void MutateOutgoing(object[] messages, NServiceBus.Unicast.Transport.TransportMessage transportMessage)
        {
            transportMessage.Headers["access_token"] = HttpContext.Current.Request.Params["access_token"];
        }

        public void Init()
        {
            Configure.Instance.Configurer.ConfigureComponent<AccessTokenMutator>(DependencyLifecycle.InstancePerCall);
        }
    }
}
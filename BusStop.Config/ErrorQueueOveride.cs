using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;

namespace BusStop.Config
{
    public class ErrorQueueOveride : IProvideConfiguration<MessageForwardingInCaseOfFaultConfig>
    {
        public MessageForwardingInCaseOfFaultConfig GetConfiguration()
        {
            return new MessageForwardingInCaseOfFaultConfig
            {
                ErrorQueue = "BusStop.Error"
            };
        }
    }
}

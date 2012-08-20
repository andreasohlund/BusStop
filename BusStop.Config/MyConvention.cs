using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace BusStop.Config
{
    public static class MyConvention
    {
        public static Configure MyMessageConventions(this Configure config)
        {
            config.DefiningEventsAs(t => t.Namespace != null && t.Namespace.EndsWith(".Contracts"));
            return config;
        }
    }
}

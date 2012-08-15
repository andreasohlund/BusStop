using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using BusStop.Contracts;

namespace BusStop.Backend
{
    class CancelOrderHandler:IHandleMessages<CancelOrder>
    {
        public IBus Bus { get; set; }

        public void Handle(CancelOrder message)
        {
            //do work
            Bus.Return<CommandStatus>(CommandStatus.Success);
        }
    }
}

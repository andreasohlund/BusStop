using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using BusStop.Contracts;
using BusStop.Billing.Contracts;

namespace BusStop.Billing.CreditCardGateway
{
    public class ChargeCreditCardHandler : IHandleMessages<ChargeCreditCard>
    {
        public ICreditCardService CreditCardService { get; set; }

        public IBus Bus { get; set; }
        
        public void Handle(ChargeCreditCard message)
        {
            var reciept = CreditCardService.Charge(message.CustomerId, message.Amount);

            Bus.Reply(new CreditCardCharged 
            { 
                CustomerId = message.CustomerId, 
                Receipt = reciept 
            });
        }
    }
}

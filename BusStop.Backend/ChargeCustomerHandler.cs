using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using BusStop.Contracts;
using NServiceBus.Config;

namespace BusStop.Backend
{
    class ChargeCustomerHandler : IHandleMessages<PlaceOrder>
    {
        public ICreditCardService CreditCardService { get; set; }
        public void Handle(PlaceOrder message)
        {
            var receipt = CreditCardService.Charge(message.CustomerId, 100);

            //todo: store receipt in raven db
        }
    }

    public interface ICreditCardService
    {
        string Charge(Guid customerId, double amount);
    }

    public class DefaultCreditCardService : ICreditCardService, INeedInitialization
    {
        public string Charge(Guid customerId, double amount)
        {
            Console.WriteLine("Customer " + customerId + " charged with: " + amount);

            return Guid.NewGuid().ToString();
        }

        public void Init()
        {
            Configure.Instance.Configurer.ConfigureComponent<DefaultCreditCardService>(DependencyLifecycle.InstancePerCall);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus.Config;
using NServiceBus;

namespace BusStop.Billing.CreditCardGateway
{
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

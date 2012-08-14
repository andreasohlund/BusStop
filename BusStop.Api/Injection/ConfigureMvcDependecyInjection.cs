namespace BusStop.Injection
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using NServiceBus;
    using System.Web.Http;
    using BusStop.Injection;

    public static class ConfigureMvcDependecyInjection
    {
        public static Configure ForWebApi(this Configure configure)
        {
            // Register our controller activator with NSB
            configure.Configurer.RegisterSingleton(typeof(IControllerActivator),
                new NServiceBusControllerActivator());

            // Find every controller class so that we can register it
            var controllers = Configure.TypesToScan
                .Where(t => typeof(ApiController).IsAssignableFrom(t));

            // Register each controller class with the NServiceBus container
            foreach (Type type in controllers)
                configure.Configurer.ConfigureComponent(type, DependencyLifecycle.InstancePerCall);

            // Set the MVC dependency resolver to use our resolver
            GlobalConfiguration.Configuration.DependencyResolver =
                new NServiceBusDependencyResolverAdapter(configure.Builder);

            return configure;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus.Config;
using Raven.Client.Document;
using NServiceBus;
using Raven.Client;

namespace BusStop.Backend
{
    public class RavenBootstrapper : INeedInitialization
    {
        public void Init()
        {
            Configure.Instance.Configurer.ConfigureComponent<IDocumentStore>(
                () =>
                {
                    var store = new DocumentStore
                                {
                                    Url = "http://localhost:8080"
                                };

                    store.Initialize();
                    store.JsonRequestFactory.DisableRequestCompression = true;
                    return store;
                }
                , DependencyLifecycle.SingleInstance);
        }
    }
}

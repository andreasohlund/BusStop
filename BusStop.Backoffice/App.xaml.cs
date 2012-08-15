using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using NServiceBus;
using NServiceBus.Installation.Environments;

namespace BusStop.Backoffice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IBus Bus { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Bus = Configure.With()
              .Log4Net()
              .DefaultBuilder()
              .XmlSerializer()
              .MsmqTransport()
              .UnicastBus()
              .CreateBus()
              .Start(()=>Configure.Instance.ForInstallationOn<Windows>().Install());

            Bus.OutgoingHeaders["access_token"] = "busstop";
        }
    }
}

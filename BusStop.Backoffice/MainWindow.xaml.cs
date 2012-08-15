using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusStop.Contracts;

namespace BusStop.Backoffice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            App.Bus.Send(new CancelOrder
            {
                OrderId = Guid.NewGuid()//get the id from a listbox in the ui
            })
            .Register<CommandStatus>(status => {
                textBox1.Text = status.ToString();
            });
        }
    }
}

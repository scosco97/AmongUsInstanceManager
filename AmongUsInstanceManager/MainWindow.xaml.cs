using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AmongUsInstanceManager
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

        private void startNumInstancesButton_Click(object sender, RoutedEventArgs e)
        {
            int numInstances;
            numInstanceField.BorderBrush = Brushes.Black;
            if (int.TryParse(numInstanceField.Text, out numInstances))
            {
                if (numInstances == 0)
                {
                    numInstanceField.BorderBrush = Brushes.Red;
                    numInstanceField.Text = "Cannot start 0 instances";
                    System.Media.SystemSounds.Exclamation.Play();
                    return;
                }
                else
                {
                    Environment.CurrentDirectory = Environment.GetEnvironmentVariable("AmongUs");
                    instanceResult.Content = $"Starting {numInstances} instances of Among Us";
                    while (numInstances != 0)
                    {
                        Process.Start("Among Us.exe");
                        Thread.Sleep(1000);
                        numInstances -= 1;
                    }
                    return;
                }
            }
            System.Media.SystemSounds.Exclamation.Play();
            numInstanceField.BorderBrush = Brushes.Red;
            numInstanceField.Text = "Input not a number";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (process.ProcessName == "Among Us")
                {
                    process.Kill();
                }
            }
            instanceResult.Content = $"Closed all instances of Among Us";
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

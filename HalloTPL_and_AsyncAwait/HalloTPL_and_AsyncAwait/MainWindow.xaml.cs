using System;
using System.Collections.Generic;
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

namespace HalloTPL_and_AsyncAwait
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

        private void StartWithoutThread(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Title = $"{i}";
                Thread.Sleep(500);
                pb1.Value = i;
            }
        }

        private void StartTask(object sender, RoutedEventArgs e)
        {
            b1.IsEnabled = false;
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    Dispatcher.Invoke(() =>
                    {
                        Title = $"{i}";
                        pb1.Value = i;
                    });
                }
                Dispatcher.Invoke(() => b1.IsEnabled = true);
            });

        }
    }
}

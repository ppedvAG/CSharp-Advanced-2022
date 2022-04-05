using System;
using System.Collections.Generic;
using System.IO;
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
                    Thread.Sleep(10);
                    Dispatcher.Invoke(() =>
                    {
                        Title = $"{i}";
                        pb1.Value = i;
                    });
                }

                Dispatcher.Invoke(() => b1.IsEnabled = true);
            });

        }

        private void StartTaskWithTs(object sender, RoutedEventArgs e)
        {
            var ts = TaskScheduler.FromCurrentSynchronizationContext();
            b2.IsEnabled = false;
            cts = new CancellationTokenSource();

            var t = Task.Run(() =>
             {
                 for (int i = 0; i < 100; i++)
                 {
                     Thread.Sleep(20);

                     //int ii = i;
                     Task.Factory.StartNew(() =>
                     {
                         Title = $"{i}";
                         pb1.Value = i;
                     }, CancellationToken.None, TaskCreationOptions.None, ts);

                     //if (i == 75)
                     //throw new OutOfMemoryException();
                     //if (cts.IsCancellationRequested) //simple
                     //    break;//todo cleanup

                     cts.Token.ThrowIfCancellationRequested(); //if you need the info, if abort was done
                 }
                 Dispatcher.Invoke(() => b2.IsEnabled = true);
             });
            t.ContinueWith(tc => MessageBox.Show("OK"), CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, ts);
            t.ContinueWith(tc =>
            {
                b2.IsEnabled = true;
                if (tc.Exception.InnerException is OperationCanceledException)
                    MessageBox.Show("Successfully aborted");
                else
                    MessageBox.Show($"ERROR: {tc.Exception.InnerException.Message}");
            }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, ts);

        }

        CancellationTokenSource cts = null;

        private void Abort(object sender, RoutedEventArgs e)
        {
            cts?.Cancel();
        }

        private async void StartAsyncAwait(object sender, RoutedEventArgs e)
        {
            cts = new CancellationTokenSource();
            for (int i = 0; i < 100; i++)
            {
                Title = $"{i}";
                pb1.Value = i;

                try
                {
                    await Task.Delay(100, cts.Token);
                }
                catch (Exception ex)
                {
                    if (ex is OperationCanceledException)
                        MessageBox.Show("Successfully aborted");
                    else
                        MessageBox.Show($"ERROR: {ex.Message}");

                    return;
                }
            }
        }

        private async void StartOldFunction(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{await MyOldFunctionAsync(400)}");
        }

        public Task<long> MyOldFunctionAsync(int anyNumber)
        {
            return Task.Run(() => MyOldFunction(anyNumber));
        }

        public long MyOldFunction(int anyNumber)
        {
            Thread.Sleep(5000);
            return anyNumber * 3;
        }
    }
}

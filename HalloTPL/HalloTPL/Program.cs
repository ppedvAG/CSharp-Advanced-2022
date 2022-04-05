using System;
using System.Threading;
using System.Threading.Tasks;

class Programm
{
    static void Main()
    {
        Console.WriteLine("Hello, World!");

        //Parallel.Invoke(Count, Count, Count, Count, Count);
        //Parallel.For(
        //    0,
        //    1000000,
        //    //new ParallelOptions() { MaxDegreeOfParallelism = 3 },
        //    i => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}"));

        Task t1 = new Task(() =>
        {
            Console.WriteLine("Task1 started");
            Thread.Sleep(3000);
            throw new ExecutionEngineException();
            Console.WriteLine("Task1 finished");
        });

        Task tc1 = t1.ContinueWith(tc =>
        {
            Console.WriteLine("Task 1 continue AWALYS");
            Thread.Sleep(3000);
            Console.WriteLine("Task 1 continue finished");
        });

        Task tc1ok = t1.ContinueWith(tc =>
        {
            Console.WriteLine("Task 1 continue OK");
        }, CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion, TaskScheduler.Default);

        Task tc1err = t1.ContinueWith(tc =>
        {
            Console.WriteLine($"Task 1 continue ERROR {tc.Exception.InnerException.Message}");
        }, CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);

        Task<long> t2 = new Task<long>(() =>
        {
            Console.WriteLine("Task2 started");
            Thread.Sleep(2000);
            Console.WriteLine("Task2 finished");
            return 45678324;
        });

        t1.Start();
        t2.Start();

        //Task.WaitAll(t1, t2, tc1);

        Console.WriteLine(t2.Result); // -> t2.Wait();

        Console.WriteLine("End");
        Console.ReadLine();
    }

    void Count()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
        }
    }
}
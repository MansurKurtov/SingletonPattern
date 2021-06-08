using System;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadPool.QueueUserWorkItem(state => TestWithThread(() => SingletonNotThreadSafe.Instance.Test()));
            //ThreadPool.QueueUserWorkItem(state => TestWithParallel(() => SingletonNotThreadSafe.Instance.Test()));
            //Console.WriteLine("Tests started!");

            ThreadPool.QueueUserWorkItem(state => TestWithThread(() => SingletonThreadSafe.Instance.Test()));
            ThreadPool.QueueUserWorkItem(state => TestWithParallel(() => SingletonThreadSafe.Instance.Test()));
            Console.WriteLine("Tests started!");

            Console.ReadKey();
        }

        private static void TestWithParallel(Action action)
        {
            for (var x = 1; x <= 50; x++)
                Parallel.Invoke(
                () =>
                {
                    Console.WriteLine($"Running {x} task:");
                    action();
                });
        }

        private static void TestWithThread(Action action)
        {
            for (var x = 1; x <= 50; x++)
                StartNewThread(()=>action());
        }
        private static void StartNewThread(Action action)
        {
            var thread1 = new Thread(s => action());
            thread1.Start();            
        }
    }
}

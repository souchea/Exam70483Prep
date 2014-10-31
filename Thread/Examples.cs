using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exam70483Prep.ThreadClass
{
    public class Examples
    {
        [ThreadStatic]
        public static int _field;

        public static ThreadLocal<int> _fieldLocal =
            new ThreadLocal<int>(() => Thread.CurrentThread.ManagedThreadId);

        public static void ThreadMethod()
        {
            foreach (int i in Enumerable.Range(0, 10))
            {
                Console.WriteLine("Write in other thread: {0}", i);
                Thread.Sleep(0);
            }
        }

        public static void SimpleThread()
        {
            var t = new Thread(new ThreadStart(ThreadMethod));
            // would work also
            // var t = new Thread(ThreadMethod);

            // background worker or not
            t.IsBackground = true;

            t.Start();

            foreach (int i in Enumerable.Range(0, 4))
            {
                Console.WriteLine("Main thread doing work");
                Thread.Sleep(0);
            }
            t.Join();
        }

        public static void StoppedThread()
        {
            bool stopped = false;

            var t2 = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running ...");
                    Thread.Sleep(1000);
                }
            }));

            t2.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            stopped = true;
            t2.Join();
        }

        public static void ThreadStaticAttributes()
        {
            new Thread(() =>
            {
                foreach (int x in Enumerable.Range(0, 10))
                {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                }
            }).Start();

            new Thread(() =>
            {
                foreach (int x in Enumerable.Range(0, 10))
                {
                    _field++;
                    Console.WriteLine("Thread B: {0}", _field);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}

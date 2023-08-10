namespace ForebackAndBackgroupThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Example -1 Foreground Thread (Bydefault all threads are foreground thread.)
            //Thread thread1 = new Thread(Method1);
            //Console.WriteLine($"Thread1 is Background thread : {thread1.IsBackground}");
            //thread1.Start();

            //Console.WriteLine("Main Thread Exited.");
            #endregion

            #region Example -2 Background Thread
            //Thread thread1 = new Thread(Method1)
            //{
            //    IsBackground = true
            //};
            //Console.WriteLine($"Thread1 is Background thread : {thread1.IsBackground}");
            //thread1.Start();

            //Console.WriteLine("Main Thread Exited.");
            #endregion

            #region Example - 3 (Multiple Foreground Threads and one Background Thread in C#)
            //Thread thread1 = new Thread(Method1)
            //{
            //};

            //Console.WriteLine($"Thread1 is a background thread : {thread1.IsBackground}");
            //thread1.Start();
            //Console.WriteLine("Main Thread Exited.");
            #endregion

            #region Example - 4 (Better understanding Background and Foreground Threads in C#)
            ThreadingTest foregroundTest = new ThreadingTest(5);
            //creating fore ground thread.
            Thread foregroundThread = new Thread(new ThreadStart(foregroundTest.RunLoop));

            ThreadingTest backgroundTest = new ThreadingTest(50);
            //creating background thread.
            Thread backgroundThread = new Thread(new ThreadStart(backgroundTest.RunLoop))
            {
                IsBackground = true
            };

            foregroundThread.Start();
            backgroundThread.Start();

            #endregion
        }

        #region Example -1 Foreground Thread 
        //public static void Method1()
        //{
        //    Console.WriteLine("Method1 Started.");
        //    for (int i = 0; i <= 5; i++)
        //    {
        //        Console.WriteLine($"Method1 - {i} is in Progress!!");
        //        Thread.Sleep(1000);
        //    }
        //    Console.WriteLine("Method1 Exited.");
        //    Console.WriteLine("Press any key to exit.");
        //    Console.ReadKey();
        //}
        #endregion

        #region Example - 3 (Multiple Foreground Threads and one Background Thread in C#)
        public static void Method1()
        {
            Console.WriteLine("Method1 Started.");
            Thread thread2 = new Thread(Method2)
            {
                IsBackground = true
            };
            thread2.Start();
            Thread.Sleep(3000);
            Console.WriteLine("Method1 Exited.");
        }
        public static void Method2()
        {
            Console.WriteLine("Method2 Started.");
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Method2 is in progress.");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Method2 Exited.");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        #endregion

        #region Example - 4 (Better understanding Background and Foreground Threads in C#)
        public class ThreadingTest
        {
            readonly int maxIterations;
            public ThreadingTest(int maxiterations)
            {
                this.maxIterations = maxiterations;
            }
            public void RunLoop()
            {
                for (int i = 0; i < maxIterations; i++)
                {
                    Console.WriteLine($"{0} count : {1}", Thread.CurrentThread.IsBackground ? "Background Thread" : "Foreground Thread", i);
                    Thread.Sleep(250);
                }
                Console.WriteLine("{0} finishing counting.", Thread.CurrentThread.IsBackground ? "Background Thread" : "Foreground Thread");
            }
        }
        #endregion

    }
}
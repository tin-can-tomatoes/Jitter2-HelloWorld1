Console.WriteLine("Hello, World!");

SpinUpThreads();

Console.WriteLine("Bye, World!");

void SpinUpThreads()
{
    void ThreadProc()
    {
        Thread.Yield();
    }

    var threads = new Thread[8];

    Console.WriteLine("Initializing.");

    var initWaitHandle = new AutoResetEvent[8]{
        new AutoResetEvent(false),
        new AutoResetEvent(false),
        new AutoResetEvent(false),
        new AutoResetEvent(false),
        new AutoResetEvent(false),
        new AutoResetEvent(false),
        new AutoResetEvent(false),
        new AutoResetEvent(false)
    };

    for (int i = 0; i < 6; i++)
    {
        int local_i = i;
        threads[i] = new Thread(() =>
            {
                Console.WriteLine($"Started thread {local_i}");
              //  Thread.Sleep(3);
                initWaitHandle[local_i].Set();
                //Console.WriteLine($"About to sleep thread {local_i}");
               // Thread.Sleep(3);
                Console.WriteLine($"About to enter loop thread {local_i}");
                while (true)
                {
                     Thread.Yield();
                }
            });

        threads[i].IsBackground = false;
        threads[i].Start();
        //Thread.Yield();
    }
    for(int i = 0; i<6;i++){
        Console.WriteLine($"Waiting on thread {i}");
        initWaitHandle[i].WaitOne();
    }
}
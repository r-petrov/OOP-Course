namespace _3.AsynchronousTimer
{
    using System;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            AsyncTimer firstAsyncTimer = new AsyncTimer(PrintFirstMessage, 5, 5000);
            firstAsyncTimer.ExecuteMethodАsync();

            AsyncTimer secondAsyncTimer = new AsyncTimer(PrintSecondMessage, 5, 1400);
            secondAsyncTimer.ExecuteMethodАsync();
        }

        internal static void PrintFirstMessage(int number)
        {
            Console.WriteLine("First test message printed at {0}: {1}", number + 1, DateTime.Now);
        }
        
        internal static void PrintSecondMessage(int number)
        {
            Console.WriteLine("Second test message printed at {0}: {1}", number + 1, DateTime.Now);
        }
    }
}

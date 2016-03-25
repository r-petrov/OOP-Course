namespace _3.AsynchronousTimer
{
    using System;
    using System.Threading;

    public class AsyncTimer
    {
        private int numberOfMethodCalls;
        private int timeInterval;

        public AsyncTimer(Action<int> methodCaller, int numberOfMethodCalls, int timeInterval)
        {
            this.NumberOfMethodCalls = numberOfMethodCalls;
            this.TimeInterval = timeInterval;
            this.MethodCaller = methodCaller;
        }

        public int NumberOfMethodCalls
        {
            get
            {
                return this.numberOfMethodCalls;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The number of method calls should be a non-negative number!");
                }

                this.numberOfMethodCalls = value;
            }
        }

        public Action<int> MethodCaller { get; private set; }

        public int TimeInterval
        {
            get
            {
                return this.timeInterval;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value of time between method calls should be a non-negative number!");
                }

                this.timeInterval = value;
            }
        }

        public void ExecuteMethodАsync()
        {
            Thread parallelThread = new Thread(this.Run);
            parallelThread.Start();
        }

        private void Run()
        {
            for (int i = 0; i < this.numberOfMethodCalls; i++)
            {
                Thread.Sleep(this.timeInterval);
                if (this.MethodCaller != null)
                {
                    this.MethodCaller(i);
                }
            }
        }
    }
}

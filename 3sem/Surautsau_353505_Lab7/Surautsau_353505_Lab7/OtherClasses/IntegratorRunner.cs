using IntegralCalculator;

namespace Surautsau_353505_Lab7.OtherClasses
{
    public class IntegratorRunner
    {
        public void RunWithDifferentPriorities()
        {
            ManualResetEventSlim doneEvent1 = new ManualResetEventSlim(false);
            ManualResetEventSlim doneEvent2 = new ManualResetEventSlim(false);
            Integral integral1 = new Integral(2);
            Integral integral2 = new Integral(2);

            Thread thread1 = new Thread(() => integral1.StartCalculation(0, 1, doneEvent1));
            thread1.Priority = ThreadPriority.Highest;

            Thread thread2 = new Thread(() => integral2.StartCalculation(0, 1, doneEvent2));
            thread2.Priority = ThreadPriority.Lowest;

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        public void RunWithSingleThread()
        {
            ManualResetEventSlim doneEvent = new ManualResetEventSlim(false);
            Integral integral = new Integral(1);
            Thread thread = new Thread(() => integral.StartCalculation(0, 1, doneEvent));
            thread.Start();
            thread.Join();
        }

        public void RunWithLimitedThreads(int maxThreads)
        {
            Integral integral = new Integral(maxThreads);
            Thread[] threads = new Thread[maxThreads];
            ManualResetEventSlim[] doneEvents = new ManualResetEventSlim[maxThreads];

            for (int i = 0; i < maxThreads; i++)
            {
                doneEvents[i] = new ManualResetEventSlim(false);
                int threadIndex = i;
                threads[i] = new Thread(() => integral.StartCalculation(0, 1, doneEvents[threadIndex]));
                threads[i].Start();
            }

            for (int i = 0; i < maxThreads; i++)
            {
                threads[i].Join();
            }
        }
    }
}

using System.Diagnostics;

namespace IntegralCalculator
{
    public class ProgressReporter
    {
        private long _prevProgressVal = -1;

        public void ReportProgress(int threadId, long progress)
        {
            if (progress - _prevProgressVal < 1) return;
            _prevProgressVal = progress;
            var progressBar = $"Thread {threadId}:[";
            var iters = (int)(progress) / 5;

            for (var i = 0; i < iters; i++)
            {
                progressBar += "=";
            }

            progressBar += ">";
            for (var i = iters; i < 20; i++)
            {
                progressBar += ' ';
            }

            progressBar += $"] {progress}%";
            Console.WriteLine(progressBar);
        }

        public void ReportCompletion(int threadId, long time, double result, long startTime)
        {
            long endTime = Stopwatch.GetTimestamp();
            Console.WriteLine($"Thread {threadId}: finished with result: {result}");
            Console.WriteLine($"Thread {threadId}: processing time: {time} ticks");
            Console.WriteLine($"Thread {threadId}: started at {startTime} ticks, finished at {endTime} ticks");
        }
    }

    public class Integral
    {
        private const double Step = 0.00000001;
        private static SemaphoreSlim _maxConcurrentSemaphore;
        private ProgressReporter _reporter;

        public Integral(int maxConcurrentThreads)
        {
            _reporter = new ProgressReporter();
            _maxConcurrentSemaphore = new SemaphoreSlim(maxConcurrentThreads);
        }

        public void CalculateSinIntegral(double start, double end, long startTime)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            double totalSteps = (end - start) / Step;
            long completedSteps = 0;
            double integralResult = 0;

            for (double x = start; x < end; x += Step)
            {
                integralResult += Math.Sin(x) * Step;
                completedSteps++;
                long progressPercentage = (completedSteps * 100) / (long)totalSteps;
                _reporter.ReportProgress(Thread.CurrentThread.ManagedThreadId, progressPercentage);
            }

            stopwatch.Stop();
            _reporter.ReportCompletion(Thread.CurrentThread.ManagedThreadId, stopwatch.ElapsedTicks, integralResult, startTime);
        }

        public async void StartCalculation(double start, double end, ManualResetEventSlim doneEvent)
        {
            await _maxConcurrentSemaphore.WaitAsync();

            try
            {
                long startTime = Stopwatch.GetTimestamp();
                CalculateSinIntegral(start, end, startTime);
            }
            finally
            {
                doneEvent.Set();
                _maxConcurrentSemaphore.Release();
            }
        }
    }
}
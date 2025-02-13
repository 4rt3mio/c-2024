using Surautsau_353505_Lab7.OtherClasses;

IntegratorRunner runner = new IntegratorRunner();

Console.WriteLine("Запуск двух потоков с различными приоритетами:");
runner.RunWithDifferentPriorities();

Console.WriteLine("\nЗапуск с ограничением на один поток:");
runner.RunWithSingleThread();

Console.WriteLine("\nЗапуск с ограничением на три потока:");
runner.RunWithLimitedThreads(3);
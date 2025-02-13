using StreamService;
using Employ;

class Program
{
    static async Task Main(string[] args)
    {
        var employees = new List<Employee>();
        Random random = new Random();

        for (int i = 0; i < 100; i++)
        {
            employees.Add(new Employee { Id = i, Name = $"Employee {i}", Age = random.Next(18, 65) });
        }

        var service = new StreamService<Employee>();
        using MemoryStream memoryStream = new MemoryStream();
        IProgress<string> progress = new Progress<string>(msg => Console.WriteLine(msg));

        Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}: Начало работы.");

        var writeTask = Task.Run(()=>service.WriteToStreamAsync(memoryStream, employees, progress));
        await Task.Delay(150);  

        memoryStream.Seek(0, SeekOrigin.Begin); 
        var copyTask = Task.Run(() => service.CopyFromStreamAsync(memoryStream, "output.txt", progress));

        Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}: Потоки записи и копирования запущены.");

        //await Task.WhenAll(writeTask, copyTask);

        Task.WaitAll(writeTask, copyTask);

        int stats = await service.GetStatisticsAsync("output.txt", e => e.Age > 35);
        Console.WriteLine($"Количество сотрудников старше 35 лет: {stats}");
    }
}
namespace StreamService
{
    public class StreamService<T>
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public async Task WriteToStreamAsync(Stream stream, IEnumerable<T> data, IProgress<string> progress)
        {
            await _semaphore.WaitAsync();
            try
            {
                progress.Report($"Поток {Thread.CurrentThread.ManagedThreadId}: Вход в метод записи.");

                using (var writer = new StreamWriter(stream, leaveOpen: true))
                {
                    foreach (var item in data)
                    {
                        await Task.Delay(200);
                        //Thread.Sleep(20);
                        string json = System.Text.Json.JsonSerializer.Serialize(item);
                        await writer.WriteLineAsync(json);
                        progress.Report($"Поток {Thread.CurrentThread.ManagedThreadId}: Записан объект {json}.");
                    }

                    await writer.FlushAsync(); 
                    progress.Report($"Поток {Thread.CurrentThread.ManagedThreadId}: Запись завершена.");
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task CopyFromStreamAsync(Stream stream, string filename, IProgress<string> progress)
        {
            await _semaphore.WaitAsync();
            try
            {
                progress.Report($"Поток {Thread.CurrentThread.ManagedThreadId}: Вход в метод копирования.");
                stream.Seek(0, SeekOrigin.Begin); 

                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        await Task.Delay(100);
                        await writer.WriteLineAsync(line);
                        progress.Report($"Поток {Thread.CurrentThread.ManagedThreadId}: Скопирован объект {line}.");
                    }
                }

                progress.Report($"Поток {Thread.CurrentThread.ManagedThreadId}: Копирование завершено.");
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<int> GetStatisticsAsync(string filename, Func<T, bool> filter)
        {
            int count = 0;
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    T obj = System.Text.Json.JsonSerializer.Deserialize<T>(line);
                    if (filter(obj))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
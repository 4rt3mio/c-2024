using Surautsau_353505_Lab6.Interfaces;
using System.Text.Json;

namespace FileService
{
    public class FileService<T> : IFileServices<T> where T : class
    {
        public IEnumerable<T> ReadFile(string fileName)
        {
            using var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            return JsonSerializer.Deserialize<IEnumerable<T>>(fileStream) ?? new List<T>();
        }

        public void SaveData(IEnumerable<T> data, string fileName)
        {
            using var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            JsonSerializer.Serialize(fileStream, data);
        }
    }
}

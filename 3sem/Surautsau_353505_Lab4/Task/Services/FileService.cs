using Task.Entities;
using Task.Interfaces;

namespace Task.Services
{
    public class FileService : IFileService<Employee>
    {
        public IEnumerable<Employee> ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"File '{fileName}' not found.");
            }

            var employees = new List<Employee>();

            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(stream))
            {
                while (stream.Position < stream.Length)
                {
                    try
                    {
                        var employee = new Employee
                        {
                            Id = reader.ReadInt32(),
                            Name = reader.ReadString(),
                            Position = reader.ReadString()
                        };
                        employees.Add(employee);
                    }
                    catch (EndOfStreamException)
                    {
                        break;
                    }
                    catch (IOException ex)
                    {
                        throw new IOException("Error reading from file.", ex);
                    }
                }
            }

            return employees;
        }

        public void SaveData(IEnumerable<Employee> data, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            using (var writer = new BinaryWriter(stream))
            {
                foreach (var employee in data)
                {
                    try
                    {
                        writer.Write(employee.Id);
                        writer.Write(employee.Name);
                        writer.Write(employee.Position);
                    }
                    catch (IOException ex)
                    {
                        throw new IOException("Error writing to file.", ex);
                    }
                }
            }
        }
    }
}

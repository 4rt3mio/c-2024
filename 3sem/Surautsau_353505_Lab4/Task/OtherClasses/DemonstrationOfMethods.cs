using System.Linq;
using Task.Entities;
using Task.Services;

namespace Task.OtherClasses
{
    public static class DemonstrationOfMethods
    {
        public static void Run()
        {
            string directoryPath = "Surautsau_Lab4";
            if (Directory.Exists(directoryPath))
            {
                // Удаление содержимого папки
                var files = Directory.GetFiles(directoryPath);
                foreach (var file in files)
                {
                    File.Delete(file);
                }
                Console.WriteLine("Содержимое папки удалено.");
            }
            else
            {
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine("Папка создана.");
            }

            // Генерация 10 случайных файлов
            string[] extensions = { ".txt", ".rtf", ".dat", ".inf" };
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                string fileName = Path.Combine(directoryPath, $"{Guid.NewGuid()}{extensions[random.Next(extensions.Length)]}");
                File.Create(fileName).Close();
                Console.WriteLine($"Создан файл: {fileName}");
            }

            // Вывод списка файлов в папке
            var filesInDirectory = Directory.GetFiles(directoryPath);
            foreach (var file in filesInDirectory)
            {
                Console.WriteLine($"Файл: {Path.GetFileName(file)} имеет расширение {Path.GetExtension(file)}");
            }

            // Создание коллекции объектов Employee
            var employees = new List<Employee>
            {
            new Employee { Id = 1, Name = "Ivan", Position = "Developer" },
            new Employee { Id = 2, Name = "Petr", Position = "Manager" },
            new Employee { Id = 3, Name = "Anna", Position = "Designer" },
            new Employee { Id = 4, Name = "Svetlana", Position = "Analyst" },
            new Employee { Id = 5, Name = "Alex", Position = "Tester" }
            };

            // Запись данных в файл
            var fileService = new FileService();
            string employeeFileName = Path.Combine(directoryPath, "employees.dat");
            fileService.SaveData(employees, employeeFileName);

            // Переименование файла
            string renamedFileName = Path.Combine(directoryPath, "employees_renamed.dat");
            File.Move(employeeFileName, renamedFileName);

            // Чтение данных из нового файла
            var loadedEmployees = fileService.ReadFile(renamedFileName).ToList();

            // Сортировка с помощью MyCustomComparer
            var sortedEmployees = loadedEmployees.OrderBy(e => e, new MyCustomComparer()).ToList();

            // Вывод исходной и отсортированной коллекций
            Console.WriteLine("\nИсходная коллекция сотрудников:");
            foreach (var employee in loadedEmployees)
            {
                Console.WriteLine($"{employee.Id}: {employee.Name} - {employee.Position}");
            }

            Console.WriteLine("\nОтсортированная коллекция сотрудников по имени:");
            foreach (var employee in sortedEmployees)
            {
                Console.WriteLine($"{employee.Id}: {employee.Name} - {employee.Position}");
            }

            // Дополнительная сортировка по Id с лямбда-выражением
            var sortedById = loadedEmployees.OrderBy(e => e.Id).ToList();

            Console.WriteLine("\nОтсортированная коллекция сотрудников по Id:");
            foreach (var employee in sortedById)
            {
                Console.WriteLine($"{employee.Id}: {employee.Name} - {employee.Position}");
            }
        }
    }
}

using Surautsau_353505_Lab6.Entities;
using System.Reflection;

var employees = new List<Employee>
{
                new Employee(1, "Alice", true),
                new Employee(2, "Bob", false),
                new Employee(3, "Charlie", true),
                new Employee(4, "David", true),
                new Employee(5, "Eva", false)
};

var assembly = Assembly.LoadFrom("D:\\csharp\\3sem\\Surautsau_353505_Lab6\\FIleService\\bin\\Debug\\net8.0\\FileService.dll");
var fileServiceType = assembly.GetType("FileService.FileService`1").MakeGenericType(typeof(Employee));
var fileService = Activator.CreateInstance(fileServiceType);

string fileName = "employees.json";
var saveMethod = fileServiceType.GetMethod("SaveData");
saveMethod.Invoke(fileService, new object[] { employees, fileName });

Console.WriteLine("Содержимое файла employees.json:");
string jsonContent = File.ReadAllText(fileName);
Console.WriteLine(jsonContent);

var readMethod = fileServiceType.GetMethod("ReadFile");
var readEmployees = readMethod.Invoke(fileService, new object[] { fileName }) as IEnumerable<Employee>;

Console.WriteLine("Содержимое файла:");
foreach (var employee in readEmployees)
{
    Console.WriteLine(employee.ToString());
}
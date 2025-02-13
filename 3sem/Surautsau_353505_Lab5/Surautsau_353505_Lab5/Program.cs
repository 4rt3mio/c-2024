using Microsoft.Extensions.Configuration;
using SerializerLib;
using Surautsau_353505_Lab5.Domain.Entities;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string xmlFileName = config["FileSettings:XmlFile"];
string jsonFileName = config["FileSettings:JsonFile"];
string linqXmlFileName = config["FileSettings:LinqXmlFile"];

var factories = new List<Factory>
{
                new Factory("Factory1", new Warehouse("Warehouse1", "Location1")),
                new Factory("Factory2", new Warehouse("Warehouse2", "Location2")),
                new Factory("Factory3", new Warehouse("Warehouse3", "Location3")),
                new Factory("Factory4", new Warehouse("Warehouse4", "Location4")),
                new Factory("Factory5", new Warehouse("Warehouse5", "Location5"))
};

var serializer = new Serializer();

serializer.SerializeXml(factories, xmlFileName);
serializer.SerializeJson(factories, jsonFileName);
serializer.SerializeByLinq(factories, linqXmlFileName);

Console.WriteLine($"Содержимое файла {xmlFileName}:");
Console.WriteLine(File.ReadAllText(xmlFileName));
Console.WriteLine($"Содержимое файла {jsonFileName}:");
Console.WriteLine(File.ReadAllText(jsonFileName));
Console.WriteLine($"Содержимое файла {linqXmlFileName}:");
Console.WriteLine(File.ReadAllText(linqXmlFileName));

var factoriesFromXml = serializer.DeSerializeXml(xmlFileName);
var factoriesFromJson = serializer.DeSerializeJson(jsonFileName);
var factoriesFromLinqXml = serializer.DeSerializeByLinq(linqXmlFileName);

bool xmlMatch = factories.SequenceEqual(factoriesFromXml);
bool jsonMatch = factories.SequenceEqual(factoriesFromJson);
bool linqXmlMatch = factories.SequenceEqual(factoriesFromLinqXml);

Console.WriteLine($"Сравнение с XML: {xmlMatch}");
Console.WriteLine($"Сравнение с JSON: {jsonMatch}");
Console.WriteLine($"Сравнение с LINQ XML: {linqXmlMatch}");
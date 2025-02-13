using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml;
using Surautsau_353505_Lab5.Domain.Entities;
using Surautsau_353505_Lab5.Domain.Interfaces;
using Newtonsoft.Json;
namespace SerializerLib
{
    public class Serializer : ISerializer
    {
        public void SerializeByLinq(IEnumerable<Factory> factories, string fileName)
        {
            var xml = new XElement("Factories",
                factories.Select(f =>
                    new XElement("Factory",
                        new XElement("Name", f.Name),
                        new XElement("Warehouse",
                            new XElement("Name", f.Warehouse.Name),
                            new XElement("Location", f.Warehouse.Location),
                            new XElement("PartCount", f.Warehouse.PartCount)
                        )
                    )
                )
            );

            xml.Save(fileName);
        }

        public IEnumerable<Factory> DeSerializeByLinq(string fileName)
        {
            var xml = XElement.Load(fileName);
            return xml.Elements("Factory").Select(f =>
                new Factory(
                    f.Element("Name").Value,
                    new Warehouse(
                        f.Element("Warehouse").Element("Name").Value,
                        f.Element("Warehouse").Element("Location").Value
                    )
                )
            );
        }

        public void SerializeXml(IEnumerable<Factory> factories, string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Factory>));
            using (var writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, factories.ToList());
            }
        }

        public IEnumerable<Factory> DeSerializeXml(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Factory>));
            using (var reader = new StreamReader(fileName))
            {
                return (List<Factory>)serializer.Deserialize(reader);
            }
        }

        public void SerializeJson(IEnumerable<Factory> factories, string fileName)
        {
            var json = JsonConvert.SerializeObject(factories.ToList(), Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        public IEnumerable<Factory> DeSerializeJson(string fileName)
        {
            var json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<List<Factory>>(json);
        }
    }
}

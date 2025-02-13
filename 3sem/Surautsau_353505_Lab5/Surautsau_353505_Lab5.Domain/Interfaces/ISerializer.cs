using Surautsau_353505_Lab5.Domain.Entities;

namespace Surautsau_353505_Lab5.Domain.Interfaces
{
    public interface ISerializer
    {
        IEnumerable<Factory> DeSerializeByLinq(string fileName);
        IEnumerable<Factory> DeSerializeXml(string fileName);
        IEnumerable<Factory> DeSerializeJson(string fileName);
        void SerializeByLinq(IEnumerable<Factory> xxx, string fileName);
        void SerializeXml(IEnumerable<Factory> xxx, string fileName);
        void SerializeJson(IEnumerable<Factory> xxx, string fileName);
    }
}

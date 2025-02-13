namespace Surautsau_353505_Lab5.Domain.Entities
{
    public class Warehouse : IEquatable<Warehouse>
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int PartCount { get; set; }

        public Warehouse() { }

        public Warehouse(string name, string location)
        {
            Name = name;
            Location = location;
            PartCount = 0;
        }

        public void UpdatePartCount(int count)
        {
            PartCount = count;
        }

        public void ReceiveParts(int quantity)
        {
            PartCount += quantity;
            Console.WriteLine($"Склад {Name} принял {quantity} деталей. Общее количество: {PartCount}.");
        }

        public bool Equals(Warehouse other)
        {
            if (other == null) return false;
            return Name == other.Name && Location == other.Location;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Warehouse);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Location);
        }
    }
}

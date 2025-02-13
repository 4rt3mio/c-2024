namespace Surautsau_353505_Lab5.Domain.Entities
{
    public class Factory : IEquatable<Factory>
    {
        public string Name { get; set; }
        public Warehouse Warehouse { get; set; } 
        public Factory() { }

        public Factory(string name, Warehouse warehouse)
        {
            Name = name;
            Warehouse = warehouse;
        }

        public void ProduceParts(int quantity)
        {
            Console.WriteLine($"Завод {Name} произвел {quantity} деталей.");
            Warehouse.ReceiveParts(quantity);
        }


        public bool Equals(Factory other)
        {
            if (other == null) return false;
            return Name == other.Name && Warehouse.Equals(other.Warehouse);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Factory);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Warehouse);
        }
    }
}

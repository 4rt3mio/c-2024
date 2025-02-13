namespace Surautsau_353505_Lab6.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }

        public Employee() { }

        public Employee(int id, string name, bool isActive)
        {
            Id = id;
            Name = name;
            IsActive = isActive;
        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Active: {IsActive}";
        }
    }
}

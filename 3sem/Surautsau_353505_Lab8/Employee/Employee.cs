namespace Employ
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public bool IsOlderThan35 => Age > 35;
    }
}
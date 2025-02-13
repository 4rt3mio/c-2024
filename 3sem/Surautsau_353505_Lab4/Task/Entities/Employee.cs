using Task.Interfaces;

namespace Task.Entities
{
    public class Employee : IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public void Work()
        {
            Console.WriteLine($"{Name} is working as {Position}.");
        }
    }
}

using System.Collections.Generic;

namespace Task.Entities
{
    public class Passenger<T>
    {
        public string PassportNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Ticket<T>> Tickets { get; set; }

        public Passenger(string passportNumber, string name, string surname)
        {
            PassportNumber = passportNumber;
            Name = name;
            Surname = surname;
            Tickets = new List<Ticket<T>>(); 
        }
    }
}
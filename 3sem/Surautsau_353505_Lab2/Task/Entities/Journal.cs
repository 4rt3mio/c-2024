using Task.Collections;
using System.Numerics;

namespace Task.Entities
{
    public class Journal<T> where T : INumber<T>
    {
        private MyCustomCollection<string> _passengerLogs = new MyCustomCollection<string>();
        private MyCustomCollection<string> _tariffLogs = new MyCustomCollection<string>();
        private MyCustomCollection<string> _ticketLogs = new MyCustomCollection<string>();

        public void AddPassengerEvent(Airport<T>.Passenger passenger)
        {
            var logEntry = $"Passenger registered: {passenger.Name} {passenger.Surname} (Passport: {passenger.PassportNumber})";
            _passengerLogs.Add(logEntry);
            Console.WriteLine(logEntry);
        }

        public void AddTariffEvent(Airport<T>.Tariff tariff)
        {
            var logEntry = $"Tariff added: {tariff.Destination}, Price: {tariff.Price}";
            _tariffLogs.Add(logEntry);
            Console.WriteLine(logEntry);
        }

        public void TicketPurchasedEvent(Airport<T>.Ticket ticket)
        {
            var logEntry = $"Ticket purchased: {ticket.Destination}, Date: {ticket.FlightDate}, Price: {ticket.Price}";
            _ticketLogs.Add(logEntry);
            Console.WriteLine(logEntry);
        }

        public void DisplayLogs()
        {
            Console.WriteLine("Passenger Logs:");
            foreach (var log in _passengerLogs)
            {
                Console.WriteLine(log);
            }

            Console.WriteLine("Tariff Logs:");
            foreach (var log in _tariffLogs)
            {
                Console.WriteLine(log);
            }

            Console.WriteLine("Ticket Logs:");
            foreach (var log in _ticketLogs)
            {
                Console.WriteLine(log);
            }
        }
    }
}

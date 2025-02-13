namespace Task.Entities
{
    public class Journal<T>
    {
        private List<string> _passengerLogs = new List<string>();
        private List<string> _tariffLogs = new List<string>();
        private List<string> _ticketLogs = new List<string>();

        public void AddPassengerEvent(Passenger<T> passenger)
        {
            var logEntry = $"Passenger registered: {passenger.Name} {passenger.Surname} (Passport: {passenger.PassportNumber})";
            _passengerLogs.Add(logEntry);
            Console.WriteLine(logEntry);
        }

        public void AddTariffEvent(string destination, T price)
        {
            var logEntry = $"Tariff added: {destination}, Price: {price}";
            _tariffLogs.Add(logEntry);
            Console.WriteLine(logEntry);
        }

        public void TicketPurchasedEvent(Ticket<T> ticket)
        {
            var logEntry = $"Ticket purchased: {ticket.Tariff.Destination}, Date: {ticket.FlightDate}, Price: {ticket.Tariff.Price}";
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
using Task.Collections;
using Task.Entities;
using Task.Interfaces;

namespace Task.OtherClasses
{
    public static class DemonstrationOfMethods
    {
        public static void Run()
        {
            var airport = new Airport<decimal>();
            var journal = new Journal<decimal>();

            // Подписка на события с использованием лямбда-выражений
            airport.PassengerRegisteredEvent += passenger =>
            {
                Console.WriteLine($"Lambda: Passenger registered: {passenger.Name} {passenger.Surname}");
                journal.AddPassengerEvent(passenger);
            };

            airport.TariffAddedEvent += tariff =>
            {
                Console.WriteLine($"Lambda: Tariff added: {tariff.Destination}, Price: {tariff.Price}");
                journal.AddTariffEvent(tariff);
            };

            airport.TicketPurchasedEvent += ticket =>
            {
                Console.WriteLine($"Lambda: Ticket purchased: {ticket.Destination}, Date: {ticket.FlightDate}, Price: {ticket.Price}");
                journal.TicketPurchasedEvent(ticket);
            };

            try
            {
                airport.AddTariff("New York", 100m);
                airport.AddTariff("London", 200m);

                airport.RegisterPassenger("123456", "Ivan", "Ivanov");
                airport.RegisterPassenger("654321", "Petr", "Petrov");

                airport.PurchaseTicket("123456", "New York", DateTime.Now);
                airport.PurchaseTicket("654321", "London", DateTime.Now);

                airport.PurchaseTicket("000000", "Nonexistent", DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }

            // Вывод логов
            journal.DisplayLogs();

            // Демонстрация работы foreach для пассажиров
            Console.WriteLine("\nPassengers:");
            foreach (var passenger in airport.passengers)
            {
                Console.WriteLine($"{passenger.Name} {passenger.Surname} (Passport: {passenger.PassportNumber})");
            }

            // Демонстрация работы foreach для тарифов
            Console.WriteLine("\nTariffs:");
            foreach (var tariff in airport.tariffs)
            {
                Console.WriteLine($"{tariff.Destination} - Price: {tariff.Price}");
            }
        }
    }
}

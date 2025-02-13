using System;
using Task.Entities;

namespace Task.OtherClasses
{
    public static class DemonstrationOfMethods
    {
        public static void Run()
        {
            var airport = new Airport<int>();
            var journal = new Journal<int>(); 

            // Подписка на события с использованием лямбда-выражений
            airport.PassengerRegisteredEvent += passenger =>
            {
                Console.WriteLine($"Lambda: Passenger registered: {passenger.Name} {passenger.Surname}");
                journal.AddPassengerEvent(passenger);
            };

            airport.TariffAddedEvent += (destination, price) =>
            {
                Console.WriteLine($"Lambda: Tariff added: {destination}, Price: {price}");
                journal.AddTariffEvent(destination, price);
            };

            airport.TicketPurchasedEvent += ticket =>
            {
                Console.WriteLine($"Lambda: Ticket purchased: {ticket.Tariff.Destination}, Date: {ticket.FlightDate}, Price: {ticket.Tariff.Price}");
                journal.TicketPurchasedEvent(ticket);
            };

            try
            {
                airport.AddTariff("New York", 500);
                airport.AddTariff("London", 700);
                airport.AddTariff("Paris", 300);
                airport.AddTariff("Tokyo", 800);
                airport.AddTariff("Berlin", 400);
                airport.AddTariff("Moscow", 600);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding tariff: {ex.Message}");
            }

            try
            {
                airport.RegisterPassenger("123456", "Ivan", "Ivanov");
                airport.RegisterPassenger("654321", "Petr", "Petrov");
                airport.RegisterPassenger("789012", "Anna", "Sidorova");
                airport.RegisterPassenger("345678", "John", "Doe");
                airport.RegisterPassenger("901234", "Sarah", "Connor");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering passenger: {ex.Message}");
            }

            try
            {
                airport.PurchaseTicket("123456", "New York", DateTime.Now);
                airport.PurchaseTicket("654321", "London", DateTime.Now);
                airport.PurchaseTicket("789012", "Paris", DateTime.Now);
                airport.PurchaseTicket("345678", "Tokyo", DateTime.Now);
                airport.PurchaseTicket("901234", "Berlin", DateTime.Now);
                airport.PurchaseTicket("123456", "Moscow", DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error purchasing ticket: {ex.Message}");
            }

            journal.DisplayLogs();

            // Запросы LINQ
            // 1. Получение списка названий всех тарифов, отсортированного по стоимости
            var sortedTariffs = airport.GetSortedTariffs();
            Console.WriteLine("\nSorted Tariffs:");
            foreach (var tariff in sortedTariffs)
            {
                Console.WriteLine(tariff);
            }

            // 2. Получение общей стоимости всех купленных в аэропорту билетов
            double totalTicketCost = airport.GetTotalTicketCost();
            Console.WriteLine($"Total cost of all purchased tickets: {totalTicketCost}");

            // 3. Получение общей стоимости всех купленных пассажиром билетов
            double ivanTotalCost = airport.GetPassengerTotalCost("123456");
            Console.WriteLine($"Total cost of tickets for Ivan: {ivanTotalCost}");

            // 4. Получение имени пассажира, заплатившего максимальную сумму
            string maxPayingPassenger = airport.GetMaxPayingPassenger();
            Console.WriteLine($"Passenger who paid the maximum amount: {maxPayingPassenger}");

            // 5. Получение количества пассажиров, заплативших больше определенной суммы
            int thresholdAmount = 600;
            int countAboveAmount = airport.CountPassengersAboveAmount(thresholdAmount);
            Console.WriteLine($"Number of passengers who paid more than {thresholdAmount}: {countAboveAmount}");

            // 6. Получение списка сумм, заплаченных по каждому направлению
            var passengerCostsByDestination = airport.GetPassengerCostsByDestination("123456");
            Console.WriteLine("Amounts paid by Ivan for each destination:");
            foreach (var cost in passengerCostsByDestination)
            {
                Console.WriteLine($"{cost.Key}: {cost.Value}");
            }
        }
    }
}
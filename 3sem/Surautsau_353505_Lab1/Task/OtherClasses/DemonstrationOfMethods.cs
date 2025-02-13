using Task.Collections;
using Task.Entities;
using Task.Interfaces;

namespace Task.OtherClasses
{
    public static class DemonstrationOfMethods
    {
        public static void Run()
        {
            IAirportSystem<int> airportSystem = new Airport<int>();

            airportSystem.AddTariff("Bobruisk", 500);
            airportSystem.AddTariff("Minsk", 700);
            airportSystem.AddTariff("Brest", 900);

            airportSystem.RegisterPassenger("AB123456", "Artem", "Ivanov");
            airportSystem.RegisterPassenger("CD789012", "Kate", "NepridumalSurnamebebebebebe");

            try
            {
                airportSystem.PurchaseTicket("AB123456", "Bobruisk", DateTime.Now.AddDays(10));
                airportSystem.PurchaseTicket("AB123456", "Minsk", DateTime.Now.AddDays(15));
                airportSystem.PurchaseTicket("CD789012", "Brest", DateTime.Now.AddDays(20));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during ticket purchase: {ex.Message}");
            }

            try
            {
                int totalCostArtem = airportSystem.CalculateTotalTicketCost("AB123456");
                Console.WriteLine($"Total cost for Artem Ivanov: {totalCostArtem}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating total cost: {ex.Message}");
            }

            DateTime flightDate = DateTime.Now.AddDays(10);
            MyCustomCollection<string> passengersOnDate = airportSystem.GetPassengersByDate(flightDate);
            Console.WriteLine($"Passengers on {flightDate.ToShortDateString()}:");

            passengersOnDate.Reset();

            var currNumberOfPassangers = 0;

            while (passengersOnDate.Count > currNumberOfPassangers)
            {
                Console.WriteLine(passengersOnDate.Current());
                passengersOnDate.Next();
                currNumberOfPassangers++;
            }
        }
    }
}

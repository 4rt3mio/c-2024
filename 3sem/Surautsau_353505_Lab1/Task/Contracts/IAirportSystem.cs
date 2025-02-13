using System.Numerics;
using Task.Collections;

namespace Task.Interfaces
{
    public interface IAirportSystem<T> where T : INumber<T>
    {
        void AddTariff(string destination, T price);
        void RegisterPassenger(string passportNumber, string name, string surname);
        void PurchaseTicket(string passportNumber, string destination, DateTime flightDate);
        T CalculateTotalTicketCost(string passportNumber);
        MyCustomCollection<string> GetPassengersByDate(DateTime flightDate);
    }
}
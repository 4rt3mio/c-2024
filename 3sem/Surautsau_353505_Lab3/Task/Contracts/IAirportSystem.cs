using System;
using System.Collections.Generic;
using System.Numerics;

namespace Task.Interfaces
{
    public interface IAirportSystem<T> where T : INumber<T>
    {
        void AddTariff(string destination, T price);
        void RegisterPassenger(string passportNumber, string name, string surname);
        void PurchaseTicket(string passportNumber, string destination, DateTime flightDate);
        T GetTotalTicketCost();
        T GetPassengerTotalCost(string passportNumber);
        List<string> GetSortedTariffs();
        string GetMaxPayingPassenger();
        int CountPassengersAboveAmount(T amount);
        Dictionary<string, T> GetPassengerCostsByDestination(string passportNumber);
    }
}
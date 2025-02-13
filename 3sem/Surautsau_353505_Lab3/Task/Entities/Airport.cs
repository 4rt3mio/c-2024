using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Task.Interfaces;

namespace Task.Entities
{
    public class Airport<T> : IAirportSystem<T> where T : INumber<T>
    {
        public delegate void PassengerRegisteredHandler(Passenger<T> passenger);
        public delegate void TariffAddedHandler(string destination, T price);
        public delegate void TicketPurchasedHandler(Ticket<T> ticket);

        public event PassengerRegisteredHandler? PassengerRegisteredEvent;
        public event TariffAddedHandler? TariffAddedEvent;
        public event TicketPurchasedHandler? TicketPurchasedEvent;

        private Dictionary<string, T> tariffs = new Dictionary<string, T>();
        private List<Passenger<T>> passengers = new List<Passenger<T>>();

        public void AddTariff(string destination, T price)
        {
            tariffs[destination] = price;
            OnTariffAddedEvent(destination, price);
        }

        public void RegisterPassenger(string passportNumber, string name, string surname)
        {
            var passenger = new Passenger<T>(passportNumber, name, surname); 
            passengers.Add(passenger);
            OnPassengerRegisteredEvent(passenger);
        }

        public void PurchaseTicket(string passportNumber, string destination, DateTime flightDate)
        {
            var passenger = FindPassenger(passportNumber);
            if (passenger != null && tariffs.TryGetValue(destination, out T price))
            {
                var tariff = new Tariff<T>(destination, price); 
                var ticket = new Ticket<T>(tariff, flightDate); 
                passenger.Tickets.Add(ticket);
                OnTicketPurchasedEvent(ticket);
            }
            else
            {
                throw new Exception("Passenger or tariff not found.");
            }
        }

        private void OnPassengerRegisteredEvent(Passenger<T> passenger)
        {
            PassengerRegisteredEvent?.Invoke(passenger);
        }

        private void OnTariffAddedEvent(string destination, T price)
        {
            TariffAddedEvent?.Invoke(destination, price);
        }

        private void OnTicketPurchasedEvent(Ticket<T> ticket)
        {
            TicketPurchasedEvent?.Invoke(ticket);
        }

        public List<string> GetSortedTariffs()
        {
            return tariffs.OrderBy(t => t.Value).Select(t => t.Key).ToList();
        }

        public T GetTotalTicketCost()
        {
            dynamic totalCost = default(T);
            foreach (var passenger in passengers)
            {
                foreach (var ticket in passenger.Tickets)
                {
                    totalCost += (dynamic)ticket.Tariff.Price;
                }
            }
            return totalCost;
        }

        public T GetPassengerTotalCost(string passportNumber)
        {
            var passenger = FindPassenger(passportNumber);
            dynamic totalCost = default(T);
            if (passenger != null)
            {
                foreach (var ticket in passenger.Tickets)
                {
                    totalCost += (dynamic)ticket.Tariff.Price;
                }
            }
            return totalCost;
        }

        public string GetMaxPayingPassenger()
        {
            return passengers
                .OrderByDescending(p => p.Tickets.Sum(t => (dynamic)t.Tariff.Price))
                .FirstOrDefault()?.Name ?? "Не найдено";
        }

        public int CountPassengersAboveAmount(T amount)
        {
            return passengers.Count(p => (dynamic)p.Tickets.Sum(t => (dynamic)t.Tariff.Price) > (dynamic)amount);
        }

        public Dictionary<string, T> GetPassengerCostsByDestination(string passportNumber)
        {
            var passenger = FindPassenger(passportNumber);
            var result = new Dictionary<string, T>();

            if (passenger != null)
            {
                var groupedCosts = passenger.Tickets
                    .GroupBy(t => t.Tariff.Destination)
                    .Select(g => new { Destination = g.Key, Total = g.Sum(t => (dynamic)t.Tariff.Price) });

                foreach (var cost in groupedCosts)
                {
                    result[cost.Destination] = (T)(dynamic)cost.Total;
                }
            }

            return result;
        }

        private Passenger<T> FindPassenger(string passportNumber)
        {
            return passengers.FirstOrDefault(p => p.PassportNumber == passportNumber);
        }
    }
}
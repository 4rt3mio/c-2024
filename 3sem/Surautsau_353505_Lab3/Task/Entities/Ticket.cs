using System;

namespace Task.Entities
{
    public class Ticket<T>
    {
        public Tariff<T> Tariff { get; set; }
        public DateTime FlightDate { get; set; }

        public Ticket(Tariff<T> tariff, DateTime flightDate)
        {
            Tariff = tariff;
            FlightDate = flightDate;
        }
    }
}
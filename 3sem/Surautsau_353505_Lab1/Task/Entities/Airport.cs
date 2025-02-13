using System.Numerics;
using Task.Collections;
using Task.Interfaces;

namespace Task.Entities
{
    public class Airport<T> : IAirportSystem<T> where T : INumber<T>
    {
        private class Tariff
        {
            public string Destination { get; set; }
            public T Price { get; set; }

            public Tariff(string destination, T price)
            {
                Destination = destination;
                Price = price;
            }
        }

        public class Passenger
        {
            public string PassportNumber { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public MyCustomCollection<Ticket> Tickets { get; set; }

            public Passenger(string passportNumber, string name, string surname)
            {
                PassportNumber = passportNumber;
                Name = name;
                Surname = surname;
                Tickets = new MyCustomCollection<Ticket>();
            }
        }

        private class Ticket
        {
            public string Destination { get; set; }
            public DateTime FlightDate { get; set; }
            public T Price { get; set; }

            public Ticket(string destination, DateTime flightDate, T price)
            {
                Destination = destination;
                FlightDate = flightDate;
                Price = price;
            }
        }

        private MyCustomCollection<Tariff> tariffs = new MyCustomCollection<Tariff>();
        private MyCustomCollection<Passenger> passengers = new MyCustomCollection<Passenger>();

        public void AddTariff(string destination, T price)
        {
            tariffs.Add(new Tariff(destination, price));
        }

        public void RegisterPassenger(string passportNumber, string name, string surname)
        {
            passengers.Add(new Passenger(passportNumber, name, surname));
        }

        public void PurchaseTicket(string passportNumber, string destination, DateTime flightDate)
        {
            var passenger = FindPassenger(passportNumber);
            var tariff = FindTariff(destination);

            if (passenger != null && tariff != null)
            {
                passenger.Tickets.Add(new Ticket(destination, flightDate, tariff.Price));
            }
            else
            {
                throw new Exception("Passenger or tariff not found.");
            }
        }

        public T CalculateTotalTicketCost(string passportNumber)
        {
            var passenger = FindPassenger(passportNumber);
            if (passenger == null)
            {
                throw new Exception("Passenger not found.");
            }

            T totalCost = T.Zero;
            passenger.Tickets.Reset();

            if (passenger.Tickets.Count == 0)
            {
                return totalCost;
            }

            var currNumberOfTickets = 0;

            while (passenger.Tickets.Count > currNumberOfTickets)
            {
                totalCost += passenger.Tickets.Current().Price;
                passenger.Tickets.Next();
                currNumberOfTickets++;
            }

            return totalCost;
        }

        public MyCustomCollection<string> GetPassengersByDate(DateTime flightDate)
        {
            var result = new MyCustomCollection<string>();
            passengers.Reset();

            if (passengers.Count == 0)
            {
                return result;
            }

            var currNumberOfPassangers = 0;

            while (passengers.Count > currNumberOfPassangers)
            {
                var passenger = passengers.Current();
                bool hasTicketOnDate = false;

                if (passenger.Tickets.Count == 0)
                {
                    passengers.Next();
                    continue;
                }

                var currNumberOfTickets = 0;

                passenger.Tickets.Reset();

                while (passenger.Tickets.Count > currNumberOfTickets)
                {
                    if (passenger.Tickets.Current().FlightDate.Date == flightDate.Date)
                    {
                        hasTicketOnDate = true;
                        break;
                    }
                    passenger.Tickets.Next();
                    currNumberOfTickets++;
                }

                if (hasTicketOnDate)
                {
                    result.Add($"{passenger.Name} {passenger.Surname} (Passport: {passenger.PassportNumber})");
                }

                passengers.Next();
                currNumberOfPassangers++;
            }

            return result;
        }

        private Passenger FindPassenger(string passportNumber)
        {
            passengers.Reset();
            while (passengers.Count > 0)
            {
                var passenger = passengers.Current();
                if (passenger.PassportNumber == passportNumber)
                {
                    return passenger;
                }
                passengers.Next();
            }
            return null;
        }

        private Tariff FindTariff(string destination)
        {
            tariffs.Reset();
            while (tariffs.Count > 0)
            {
                var tariff = tariffs.Current();
                if (tariff.Destination == destination)
                {
                    return tariff;
                }
                tariffs.Next();
            }
            return null;
        }
    }
}

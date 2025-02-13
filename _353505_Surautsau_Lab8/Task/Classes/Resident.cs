namespace Task.Classes
{
    public class Resident
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int HouseNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public double TotalServicesCost { get; private set; }

        private ServiceStrategy serviceStrategy;

        public Resident(string firstName, string lastName, string city, int houseNumber, int apartmentNumber, ServiceStrategy strategy)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
            HouseNumber = houseNumber;
            ApartmentNumber = apartmentNumber;
            serviceStrategy = strategy;
            AddServiceStrategy();
        }

        private void AddServiceStrategy()
        {
            TotalServicesCost = serviceStrategy.GetServiceCost();
        }
    }

}

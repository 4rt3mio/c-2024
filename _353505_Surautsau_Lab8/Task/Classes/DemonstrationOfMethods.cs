namespace Task.Classes
{
    public static class DemonstrationOfMethods
    {
        public static void Run()
        {
            HousingMaintenance housingMaintenance = new HousingMaintenance();
            Resident resident1 = new Resident("John", "Doe", "New York", 123, 456, new SimpleServiceStrategy());
            Resident resident2 = new Resident("Alice", "Smith", "Los Angeles", 789, 012, new AdvancedServiceStrategy());
            housingMaintenance.AddResident(resident1);
            housingMaintenance.AddResident(resident2);
            double totalCost = housingMaintenance.CalculateTotalServicesCost();
            Console.WriteLine($"Общая стоимость оказанных услуг: {totalCost}");
            foreach (var resident in housingMaintenance.residents)
            {
                Console.WriteLine($"Житель: {resident.FirstName} {resident.LastName}");
                Console.WriteLine($"Город: {resident.City}");
                Console.WriteLine($"Номер дома: {resident.HouseNumber}");
                Console.WriteLine($"Номер квартиры: {resident.ApartmentNumber}");
                Console.WriteLine($"Общая стоимость услуг: {resident.TotalServicesCost}");
                Console.WriteLine();
            }
        }

    }
}

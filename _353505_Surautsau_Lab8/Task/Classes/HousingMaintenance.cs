namespace Task.Classes
{
    public class HousingMaintenance
    {
        public List<Resident> residents { get; }

        public HousingMaintenance()
        {
            residents = new List<Resident>();
        }

        public void AddResident(Resident resident)
        {
            residents.Add(resident);
        }

        public double CalculateTotalServicesCost()
        {
            double totalCost = 0;
            foreach (var resident in residents)
            {
                totalCost += resident.TotalServicesCost;
            }
            return totalCost;
        }
        public double GetServiceCostForResident(Resident resident)
        {
            if (resident != null)
            {
                return resident.TotalServicesCost;
            }
            else
            {
                throw new ArgumentNullException("Resident cannot be null.");
            }
        }
    }
}

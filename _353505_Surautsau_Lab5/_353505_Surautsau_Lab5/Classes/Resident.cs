namespace Task.Classes
{
    public class Resident
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private readonly List<UtilityBill> utilityBills;
        public Tariff Tariff { get; set; }

        public Resident(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            utilityBills = new List<UtilityBill>();
        }

        public void AddUtilityBill(UtilityBill utilityBill)
        {
            utilityBills.Add(utilityBill);
        }

        public decimal TotalCostForUtility(UtilityType utilityType)
        {
            decimal totalCost = 0;
            foreach (var utilityBill in utilityBills)
            {
                if (utilityBill.UtilityType == utilityType)
                {
                    totalCost += utilityBill.TotalCost;
                }
            }
            return totalCost;
        }

        public decimal TotalCostForAllUtilities()
        {
            decimal totalCost = 0;
            foreach (var utilityBill in utilityBills)
            {
                totalCost += utilityBill.TotalCost;
            }
            return totalCost;
        }
    }

}

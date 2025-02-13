namespace Task.Classes
{
    public class UtilityBill
    {
        public Resident Resident { get; }
        public UtilityType UtilityType { get; }
        public int Amount { get; }

        public UtilityBill(Resident resident, UtilityType utilityType, int amount)
        {
            Resident = resident;
            UtilityType = utilityType;
            Amount = amount;
        }

        public decimal TotalCost => Resident.Tariff.GetPrice(UtilityType) * Amount;
    }
}
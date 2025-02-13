namespace Task.Classes
{
    public class Tariff
    {
        private readonly Dictionary<UtilityType, decimal> prices;

        public Tariff()
        {
            prices = new Dictionary<UtilityType, decimal>();
        }

        public void SetPrice(UtilityType utilityType, decimal price)
        {
            prices[utilityType] = price;
        }

        public decimal GetPrice(UtilityType utilityType)
        {
            return prices.ContainsKey(utilityType) ? prices[utilityType] : 0;
        }
    }
}
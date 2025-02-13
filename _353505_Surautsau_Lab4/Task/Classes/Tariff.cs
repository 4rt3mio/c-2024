namespace Task.Classes
{
    public class Tariff
    {
        public double CostTariff { get; private set; }
        public Tariff(double cost) {CostTariff = cost;}
        public void IncreasePrice(double a) {CostTariff += a;}
        public void ReducePrice(double a)
        {
            if (CostTariff > a) CostTariff -= a;
        }
    }
}
namespace Task.Classes
{
    public class AdvancedServiceStrategy : ServiceStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Расширенное выполнение услуги...");
        }
        public double GetServiceCost()
        {
            return 150;
        }
    }
}

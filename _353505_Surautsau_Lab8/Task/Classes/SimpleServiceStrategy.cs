namespace Task.Classes
{
    public class SimpleServiceStrategy : ServiceStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Простое выполнение услуги...");
        }
        public double GetServiceCost()
        {
            return 300;
        }
    }
}

namespace Task2.Services
{
    public class PerformAction
    {
        public static double DoAction(double varPerformed)
        {
            double temp;
            if (varPerformed <= 0)
            {
                temp = Math.Pow(varPerformed, 2) + 5;
                Console.WriteLine("Был выбран путь 1");
            }
            else
            {
                temp = 1 / (Math.Sqrt(varPerformed - 1));
                Console.WriteLine("Был выбран путь 2");
            }
            double result = Math.Pow(Math.Sin(Math.Pow(temp, 2) - 1), 3) + Math.Log(Math.Abs(temp)) + Math.Pow(Math.E, temp);
            return result;
        }
    }
}

namespace Task.Entities
{
    public class Tariff<T>
    {
        public string Destination { get; set; }
        public T Price { get; set; }

        public Tariff(string destination, T price)
        {
            Destination = destination;
            Price = price;
        }
    }
}
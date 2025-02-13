namespace Task.Classes
{
    public sealed class Truck : Car
    {
        public double LoadCapacity { get; set; }

        public Truck(string brand, string model, int year, double speed, string bodyType, double maxLoad, double loadCapacity)
            : base(brand, model, year, speed, bodyType, maxLoad)
        {
            LoadCapacity = loadCapacity;
        }

        public new void Start()
        {
            base.Start();
            Console.WriteLine("Truck started.");
        }

        public override string GetInfo()
        {
            return $"Truck: {Brand} {Model}, Year: {Year}, Speed: {Speed}, Body Type: {BodyType}, Max Load: {MaxLoad}, Load Capacity: {LoadCapacity}";
        }

        public override void Accelerate()
        {
            Speed += 15;
        }

        public override void Decelerate()
        {
            Speed -= 15;
        }

        public bool CheckOverload(double currentLoad)
        {
            if (currentLoad > LoadCapacity)
            {
                Console.WriteLine("Truck is overloaded!");
                return true;
            }
            else
            {
                Console.WriteLine("Truck is not overloaded.");
                return false;
            }
        }

        public override void Move()
        {
            Console.WriteLine("Truck is moving.");
        }
    }
}

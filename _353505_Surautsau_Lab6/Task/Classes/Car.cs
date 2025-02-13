namespace Task.Classes
{
    public class Car : TransportVehicle
    {
        public string Brand { get; set; }
        public string BodyType { get; set; }
        public double MaxLoad { get; set; }

        public Car(string brand, string model, int year, double speed, string bodyType, double maxLoad)
            : base(model, year, speed)
        {
            Brand = brand;
            BodyType = bodyType;
            MaxLoad = maxLoad;
        }

        public Car(string model, int year, double speed) : base(model, year, speed) { }

        public override void Accelerate()
        {
            Speed += 10;
        }

        public override void Decelerate()
        {
            Speed -= 10;
        }

        public override string GetInfo()
        {
            return $"Car: {Brand} {Model}, Year: {Year}, Speed: {Speed}, Body Type: {BodyType}, Max Load: {MaxLoad}";
        }

        public double CalculateFuelConsumption()
        {
            return 0;
        }

        public override void Move()
        {
            Console.WriteLine("Car is moving.");
        }

        public override void Start()
        {
            Console.WriteLine("Car started.");
        }

        public void ChangeSpeed(double newSpeed)
        {
            Speed = newSpeed;
        }
    }

}

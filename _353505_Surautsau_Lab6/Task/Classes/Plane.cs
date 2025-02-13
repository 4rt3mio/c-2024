namespace Task.Classes
{
    public class Plane : TransportVehicle
    {
        public string Airline { get; set; }
        public int PassengerCapacity { get; set; }

        public Plane(string model, int year, double speed, string airline, int passengerCapacity)
        : base(model, year, speed)
        {
            Airline = airline;
            PassengerCapacity = passengerCapacity;
        }

        public override void Accelerate()
        {
            Speed += 30;
        }

        public override void Decelerate()
        {
            Speed -= 30;
        }

        public void Start(int altitude)
        {
            Console.WriteLine($"Plane started and flying at altitude {altitude} meters.");
        }

        public override string GetInfo()
        {
            return $"Plane: {Model}, Year: {Year}, Speed: {Speed}, Airline: {Airline}, Passenger Capacity: {PassengerCapacity}";
        }

        public override void Move()
        {
            Console.WriteLine("Plane is flying.");
        }
    }
}

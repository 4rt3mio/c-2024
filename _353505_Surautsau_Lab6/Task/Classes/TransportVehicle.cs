namespace Task.Classes
{
    public abstract class TransportVehicle
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public double Speed { get; set; }

        protected TransportVehicle(string model, int year, double speed)
        {
            Model = model;
            Year = year;
            Speed = speed;
        }

        public abstract void Move();

        public void DisplayInfo()
        {
            Console.WriteLine($"Model: {Model}, Year: {Year}, Speed: {Speed}");
        }

        public virtual void Start()
        {
            Console.WriteLine("TransportVehicle started.");
        }

        public abstract void Accelerate();
        public abstract void Decelerate();
        public abstract string GetInfo();
    }
}

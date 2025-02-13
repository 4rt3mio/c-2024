namespace Task.Classes
{
    public class Train : TransportVehicle
    {
        public string Operator { get; set; }
        public int CarriageCount { get; set; }

        public Train(string model, int year, double speed, string @operator, int carriageCount)
        : base(model, year, speed)
        {
            Operator = @operator;
            CarriageCount = carriageCount;
        }

        public override void Accelerate()
        {
            Speed += 20;
        }

        public override void Decelerate()
        {
            Speed -= 20;
        }

        public override string GetInfo()
        {
            return $"Train: {Model}, Year: {Year}, Speed: {Speed}, Operator: {Operator}, Carriage Count: {CarriageCount}";
        }

        public override void Move()
        {
            Console.WriteLine("Train is moving on the rails.");
        }
    }
}

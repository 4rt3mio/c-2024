namespace Task.Classes
{
    public static class DemonstrationOfProgram
    {
        public static void Run()
        {
            Car car = new Car("Toyota", "Corolla", 2020, 120, "Sedan", 400);
            Console.WriteLine(car.GetInfo());

            Truck truck = new Truck("Volvo", "FH", 2018, 80, "Truck", 500, 20000);
            Console.WriteLine(truck.GetInfo());

            Plane plane = new Plane("Boeing 737", 2015, 900, "Delta", 250);
            Console.WriteLine(plane.GetInfo());

            Train train = new Train("Eurostar", 2010, 300, "Eurostar", 18);
            Console.WriteLine(train.GetInfo());
        }
    }
}
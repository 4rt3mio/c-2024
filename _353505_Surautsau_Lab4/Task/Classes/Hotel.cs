namespace Task.Classes
{
    public class Hotel
    {
        private static Hotel? _hotel;
        private string? _name;
        private int _seatedPlaces;
        private int _totalPlaces;
        private Tariff _tariff;
        private Hotel() { }

        public void SetParams(int seatedPlaces, int totalPlaces, double cost, string? name)
        {
            _seatedPlaces = seatedPlaces;
            _totalPlaces = totalPlaces;
            _tariff = new Tariff(cost);
            _name = name;
        }
        public double Revenue()
        {
            return _seatedPlaces * _tariff.CostTariff;
        }
        public void IncreasePrice(double delta)
        {
            _tariff.IncreasePrice(delta);
        }
        public void ReducePrice(double delta)
        {
            _tariff.ReducePrice(delta);
        }
        public static Hotel GetInstance()
        {
            if (_hotel == null)
            {
                _hotel = new Hotel();
            }
            return _hotel;
        }
    }
}

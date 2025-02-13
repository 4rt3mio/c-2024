namespace Task.Entities
{
    public class MyCustomComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            // Сравниваем по имени
            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }
}

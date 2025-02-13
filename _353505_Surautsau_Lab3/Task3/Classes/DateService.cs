namespace Task3.Classes
{
    public class DateService
    {
        public static string GetDay(string dat)
        {
            var dateTime = DateTime.ParseExact(dat, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            return dateTime.DayOfWeek.ToString();
        }
        public static double GetDaysSpan(int day, int month, int year)
        {
            DateTime inputDate = new DateTime(year, month, day);
            DateTime today = DateTime.Today;
            TimeSpan difference = inputDate - today;
            return difference.TotalDays;
        }
    }
}

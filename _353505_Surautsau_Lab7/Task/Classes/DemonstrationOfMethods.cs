namespace Task.Classes
{
    public static class DemonstrationOfMethods
    {
        public static void Run()
        {
            Interval interval1 = new Interval(1, 5);
            Interval interval2 = new Interval(3, 7);

            Console.WriteLine("Interval 1: " + interval1);
            Console.WriteLine("Interval 2: " + interval2);

            Console.WriteLine("Length of Interval 1: " + interval1.Length);
            Console.WriteLine("Length of Interval 2: " + interval2.Length);

            Interval intersection = interval1 - interval2;
            Console.WriteLine("Intersection of Interval 1 and Interval 2: " + intersection);

            Interval union = interval1 + interval2;
            Console.WriteLine("Union of Interval 1 and Interval 2: " + union);

            Interval incrementedInterval = ++interval1;
            Console.WriteLine("Incremented Interval 1: " + incrementedInterval);

            Interval decrementedInterval = --interval2;
            Console.WriteLine("Decremented Interval 2: " + decrementedInterval);

            bool isEqualLength = interval1 == interval2;
            Console.WriteLine("Is Interval 1 equal in length to Interval 2: " + isEqualLength);

            bool isNotEqualLength = interval1 != interval2;
            Console.WriteLine("Is Interval 1 not equal in length to Interval 2: " + isNotEqualLength);

            bool isShorter = interval1 < interval2;
            Console.WriteLine("Is Interval 1 shorter than Interval 2: " + isShorter);

            bool isLonger = interval1 > interval2;
            Console.WriteLine("Is Interval 1 longer than Interval 2: " + isLonger);

            double intervalLength = (double)interval1;
            Console.WriteLine("Length of Interval 1 (explicit conversion to double): " + intervalLength);

            Interval newInterval = (Interval)5.5;
            Console.WriteLine("New Interval: " + newInterval);

            bool intervalBool = (bool)interval2;
            Console.WriteLine("Is Interval 2 non-zero: " + intervalBool);

            Interval zeroInterval = (Interval)false;
            Console.WriteLine("Zero Interval: " + zeroInterval);

        }
    }
}

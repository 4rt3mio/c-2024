namespace Task.Classes
{
    public class Interval
    {
        private double start;
        private double end;

        public Interval(double start, double end)
        {
            if (start > end)
            {
                throw new ArgumentException();
            }

            this.start = start;
            this.end = end;
        }

        public double Start
        {
            get { return start; }
            set
            {
                if (value <= end)
                {
                    start = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public double End
        {
            get { return end; }
            set
            {
                if (value >= start)
                {
                    end = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public double Length
        {
            get { return end - start; }
        }

        public override string ToString()
        {
            return $"[{start}, {end}]";
        }

        public static Interval operator +(Interval a, Interval b)
        {
            double newStart = Math.Max(a.start, b.start);
            double newEnd = Math.Min(a.end, b.end);
            return new Interval(newStart, newEnd);
        }

        public static Interval operator -(Interval a, Interval b)
        {
            if (a.end < b.start || b.end < a.start)
            {
                throw new InvalidOperationException();
            }

            double newStart = Math.Max(a.start, b.start);
            double newEnd = Math.Min(a.end, b.end);
            return new Interval(newStart, newEnd);
        }

        public static Interval operator ++(Interval a)
        {
            return new Interval(a.start - 1, a.end + 1);
        }

        public static Interval operator --(Interval a)
        {
            if (a.Length == 0)
            {
                throw new InvalidOperationException();
            }

            return new Interval(a.start + 1, a.end - 1);
        }

        public static bool operator ==(Interval a, Interval b)
        {
            return a.Start == b.Start && a.End == b.End;
        }

        public static bool operator !=(Interval a, Interval b)
        {
            return !(a == b);
        }

        public static bool operator <(Interval a, Interval b)
        {
            return a.Length < b.Length;
        }

        public static bool operator >(Interval a, Interval b)
        {
            return a.Length > b.Length;
        }

        public static explicit operator double(Interval a)
        {
            return a.Length;
        }

        public static explicit operator Interval(double length)
        {
            return new Interval(0, length);
        }

        public static explicit operator bool(Interval a)
        {
            return a.Length != 0;
        }

        public static explicit operator Interval(bool value)
        {
            if (value)
            {
                return new Interval(0, 1);
            }
            else
            {
                return new Interval(0, 0);
            }
        }
    }
}

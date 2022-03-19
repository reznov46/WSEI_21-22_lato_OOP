using System;

namespace Project
{
    public class Fraction : IEquatable<Fraction>, IComparable<Fraction>
    {
        private int Numerator { get; set; }
        private int Denominator { get; set; }
        public Fraction() { }
        public Fraction(int Num, int Denom)
        {
            if (Denom == 0)
                throw new ArgumentException("Denominator cannot be 0.", nameof(Denom));
            (int n, int d) = Simplify(Num, Denom);
            Numerator = n;
            Denominator = d;
        }
        public Fraction(Fraction obj) : this(obj.Numerator, obj.Denominator)
        {
        }
        public bool Equals(Fraction other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return (Numerator * other.Denominator == other.Numerator * Denominator);
        }
        public bool Equals(Fraction a, Fraction b)
        {
            if (a == null || b == null) return false;
            return (a.Numerator * b.Denominator == b.Numerator * a.Denominator);
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Fraction);
        }
        public int CompareTo(Fraction other)
        {
            if (other == null)
                return 1;
            int a = Numerator * other.Denominator;
            int b = other.Numerator * Denominator;
            if (a - b > 0)
                return 1;
            else if (a - b < 0)
                return -1;
            else
                return 0;
        }

        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new(-a.Numerator, a.Denominator);

        public static Fraction operator +(Fraction a, Fraction b)
            => new(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);

        public static Fraction operator -(Fraction a, Fraction b)
            => a + (-b);
        public static Fraction operator *(Fraction a, Fraction b)
            => new(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        public static bool operator ==(Fraction a, Fraction b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if (b is null)
                return false;
            if (a is null)
                return false;
            return a.Equals(b);
        }
        public static bool operator !=(Fraction a, Fraction b)
            => !(a == b);
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }
        public static bool operator <(Fraction left, Fraction right)
        {
            return left is null ? right is not null : left.CompareTo(right) < 0;
        }
        public static bool operator <=(Fraction left, Fraction right) => left is null || left.CompareTo(right) <= 0;
        public static bool operator >(Fraction left, Fraction right) => left is not null && left.CompareTo(right) > 0;
        public static bool operator >=(Fraction left, Fraction right) => left is null ? right is null : left.CompareTo(right) >= 0;
        public override string ToString() => $"{Numerator}/{Denominator}";

        public static (int, int) Simplify(int n, int d)
        {
            bool negative = n < 0;
            if (negative) n = -n;
            int gcd = GCD(n, d);
            return (negative == true ? -n / gcd : n / gcd, d / gcd);
        }

        private static int GCD(int a, int b)
        {
            while (b > 0)
            {
                int rem = a % b;
                a = b;
                b = rem;
            }
            return a;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}

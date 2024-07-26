namespace CSharp_DZ_8_1_Dedok
{
    //3
    public class Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
        }
        public static Complex operator +(Complex c1, double value)
        {
            return new Complex(c1.Real + value, c1.Imaginary);
        }

        public static Complex operator +(double value, Complex c1)
        {
            return new Complex(value + c1.Real, c1.Imaginary);
        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
        }

        public static Complex operator -(Complex c1, double value)
        {
            return new Complex(c1.Real - value, c1.Imaginary);
        }

        public static Complex operator -(double value, Complex c1)
        {
            return new Complex(value - c1.Real, -c1.Imaginary);
        }
        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(
                c1.Real * c2.Real - c1.Imaginary * c2.Imaginary,
                c1.Real * c2.Imaginary + c1.Imaginary * c2.Real
            );
        }

        public static Complex operator *(Complex c1, double value)
        {
            return new Complex(c1.Real * value, c1.Imaginary * value);
        }

        public static Complex operator *(double value, Complex c1)
        {
            return new Complex(c1.Real * value, c1.Imaginary * value);
        }
        public static Complex operator /(Complex c1, Complex c2)
        {
            double denom = c2.Real * c2.Real + c2.Imaginary * c2.Imaginary;
            return new Complex(
                (c1.Real * c2.Real + c1.Imaginary * c2.Imaginary) / denom,
                (c1.Imaginary * c2.Real - c1.Real * c2.Imaginary) / denom
            );
        }

        public static Complex operator /(Complex c1, double value)
        {
            return new Complex(c1.Real / value, c1.Imaginary / value);
        }
        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }
    }
    //4
    public class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }
        private void Simplify()
        {
            int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
            Numerator /= gcd;
            Denominator /= gcd;
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }

        public static Fraction operator +(Fraction a, double b)
        {
            return a + new Fraction((int)(b * a.Denominator), a.Denominator);
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static Fraction operator *(Fraction a, int b)
        {
            return new Fraction(a.Numerator * b, a.Denominator);
        }

        public static Fraction operator *(int a, Fraction b)
        {
            return new Fraction(a * b.Numerator, b.Denominator);
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException("Cannot divide by a fraction with zero numerator.");
            }
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }
        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.Numerator * b.Denominator == b.Numerator * a.Denominator;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return !(a == b);
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction)
            {
                Fraction other = (Fraction)obj;
                return this == other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Numerator.GetHashCode() ^ Denominator.GetHashCode();
        }
        public static bool operator true(Fraction a)
        {
            return a.Numerator < a.Denominator;
        }

        public static bool operator false(Fraction a)
        {
            return a.Numerator >= a.Denominator;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task_3 - хранение комплексных чисел
            Complex z = new Complex(1, 1);
            Complex z1;
            z1 = z - (z * z * z - 1) / (3 * z * z);
            Console.WriteLine("z1 = {0}", z1);
            Console.WriteLine();
            //Task_4 - Fraction
            Fraction f = new Fraction(3, 4);
            int a = 10;
            Fraction f1 = f * a;
            Fraction f2 = a * f;
            double d = 1.5;
            Fraction f3 = f + d;

            Console.WriteLine($"f1 = {f1}");
            Console.WriteLine($"f2 = {f2}");
            Console.WriteLine($"f3 = {f3}");
        }
    }
}

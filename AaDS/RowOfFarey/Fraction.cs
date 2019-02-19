using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ряд_Фарея.Properties
{
    class Fraction : IComparable
    {
        private double numerator;
        public double denominator;
        private double value;

        public Fraction(double num, double den)
        {
            numerator = num;
            denominator = den;
            value = num / den;
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.numerator + f2.numerator, f1.denominator + f2.denominator);
        }

        public string Print()
        {
            return $"{numerator}/{denominator}";
        }

        public int CompareTo(object obj)
        {
            var fr = (Fraction)obj;
            return value.CompareTo(fr.value);
        }
    }
}
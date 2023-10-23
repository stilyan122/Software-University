using System;

namespace CenterPoint
{
    class CenterPoint
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            Calculate(x1, y1, x2, y2);
        }
        public static void Calculate(double x1,
            double y1,
            double x2,
            double y2)
        {
            decimal length1 = (decimal)Math.Sqrt(x1*x1+y1*y1);
            decimal length2 = (decimal)Math.Sqrt(x2*x2+y2*y2);
            if (length1 <= length2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
    }
}

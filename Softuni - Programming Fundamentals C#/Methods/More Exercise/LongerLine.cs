using System;

namespace LongerLine
{
    class LongerLine
    {
        static void Main(string[] args)
        {
            double x1_1 = double.Parse(Console.ReadLine());
            double y1_1 = double.Parse(Console.ReadLine());
            double x2_1 = double.Parse(Console.ReadLine());
            double y2_1 = double.Parse(Console.ReadLine());
            double x1_2 = double.Parse(Console.ReadLine());
            double y1_2 = double.Parse(Console.ReadLine());
            double x2_2 = double.Parse(Console.ReadLine());
            double y2_2 = double.Parse(Console.ReadLine());
            Calculate(x1_1, y1_1, x2_1, y2_1, x1_2, y1_2, x2_2, y2_2);
        }
        static void Calculate(
            double x1_1, double y1_1, 
            double x2_1, double y2_1, 
            double x1_2, double y1_2, 
            double x2_2, double y2_2)
        {
            decimal line1 = (decimal)(Math.Sqrt((x2_1 - x1_1)*(x2_1 - x1_1)+(y2_1 - y1_1)*(y2_1 - y1_1)));
            decimal line2 = (decimal)(Math.Sqrt((x2_2 - x1_2)*(x2_2 - x1_2)+(y2_2 - y1_2)*(y2_2 - y1_2)));
            if (line1>=line2)
            {
                if (Calculate(x1_1,y1_1,x2_1,y2_1)==1)
                {
                    Console.WriteLine($"({x1_1}, {y1_1})({x2_1}, {y2_1})");
                }
                else
                {
                    Console.WriteLine($"({x2_1}, {y2_1})({x1_1}, {y1_1})");
                }
            }
            else
            {
                if (Calculate(x1_2, y1_2, x2_2, y2_2) == 1)
                {
                    Console.WriteLine($"({x1_2}, {y1_2})({x2_2}, {y2_2})");
                }
                else
                {
                    Console.WriteLine($"({x2_2}, {y2_2})({x1_2}, {y1_2})");
                }
            }
        }
        public static int Calculate(double x1,
           double y1,
           double x2,
           double y2)
        {
            decimal length1 = (decimal)Math.Sqrt(x1 * x1 + y1 * y1);
            decimal length2 = (decimal)Math.Sqrt(x2 * x2 + y2 * y2);
            if (length1 <= length2)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}

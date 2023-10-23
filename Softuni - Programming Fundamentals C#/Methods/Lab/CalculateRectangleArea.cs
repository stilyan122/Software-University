using System;

namespace CalculateRectangleArea
{
    class CalculateRectangleArea
    {
        static void Main(string[] args)
        {
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            double area = ReturnArea(n1, n2);
            double ReturnArea(double n1, double n2)
            {
                return n1 * n2;
            }
            Console.WriteLine(area);
        }
    }
}

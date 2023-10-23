using System;

namespace MathPower
{
    class MathPower
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            double result = PowerNum(num, power);
            double PowerNum(double number, double power)
            {
                return Math.Pow(num, power);
            }
            Console.WriteLine(result);
        }
    }
}

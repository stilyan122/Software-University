using System;

namespace Calculations
{
    class Calculations
    {
        static void Main(string[] args)
        {
            void Add(double num1, double num2)
            {
                Console.WriteLine(num1+num2);
            }
            void Multiply(double num1, double num2)
            {
                Console.WriteLine(num1 * num2);
            }
            void Subtract(double num1, double num2)
            {
                Console.WriteLine(num1 - num2);
            }
            void Divide(double num1, double num2)
            {
                Console.WriteLine(num1 / num2);
            }
            string operation = Console.ReadLine();
            double n1 = double.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine());
            switch (operation)
            {
                case "add":
                Add(n1, n2);
                break;
                case "multiply":
                Multiply(n1, n2);
                break;
                case "subtract":
                Subtract(n1, n2);
                break;
                case "divide":
                Divide(n1, n2);
                break;
            }
        }
    }
}

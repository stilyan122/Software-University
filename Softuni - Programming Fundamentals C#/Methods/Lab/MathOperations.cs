using System;

namespace MathOperations
{
    class MathOperations
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            char op = char.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());
            double result = Calculate(num1, op, num2);
            Console.WriteLine($"{result}");
        }
        static double Calculate(double num1, char op, double num2)
        {
            double result = 0.0;
            switch (op)
            {
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Error: division by zero");
                    }
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                default:
                    Console.WriteLine("Error: invalid operator");
                    break;
            }
            return result;
        }
    }
}

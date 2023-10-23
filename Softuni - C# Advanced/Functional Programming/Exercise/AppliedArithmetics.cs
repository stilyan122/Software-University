using System;
using System.Linq;

namespace AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            Func<double, double> add = num => num += 1;
            Func<double, double> multiply = num => num *= 2;
            Func<double, double> subtract = num => num -= 1;
            double[] collection = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "add")
                {
                    for (int  i = 0;  i < collection.Length;  i++)
                    {
                        collection[i] = add(collection[i]);
                    }
                }
                else if (command == "multiply")
                {
                    for (int i = 0; i < collection.Length; i++)
                    {
                        collection[i] = multiply(collection[i]);
                    }
                }
                else if (command == "subtract")
                {
                    for (int i = 0; i < collection.Length; i++)
                    {
                        collection[i] = subtract(collection[i]);
                    }
                }
                else if (command=="print")
                {
                    Console.WriteLine(string.Join(" ",collection));
                }
                command = Console.ReadLine();
            }
        }
    }
}

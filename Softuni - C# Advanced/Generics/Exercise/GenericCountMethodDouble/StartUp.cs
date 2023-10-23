using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            static int Count<T>(List<T> list, T element) where T : IComparable<T>
            {
                int counter = 0;
                foreach (var item in list)
                {
                    if (item.CompareTo(element) > 0)
                    {
                        counter++;
                    }
                }
                return counter;
            }
            List<double> items = new List<double>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                double item = double.Parse(Console.ReadLine());
                items.Add(item);
            }
            double comprarer = double.Parse(Console.ReadLine());
            int count = Count<double>(items, comprarer);
            Console.WriteLine(count);
        }
    }
}

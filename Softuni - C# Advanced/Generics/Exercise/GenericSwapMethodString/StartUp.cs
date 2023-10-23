using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        { 
            static void Swap<T>(List<T> list,int index1,int index2)
            {
                T help = list[index1];
                list[index1] = list[index2];
                list[index2] = help;
                foreach (T item in list)
                {
                    Console.WriteLine($"{item.GetType().FullName}: {item}");
                }
            }
            List<string> items = new List<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string item = Console.ReadLine();
                items.Add(item);
            }
            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int index1 = indexes[0];
            int index2 = indexes[1];
            Swap<string>(items, index1, index2);
        }
    }
}

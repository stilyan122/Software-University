using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class FashionBoutique
    {
        static void Main(string[] args)
        {
            int[] cloth = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacityFromConsole = int.Parse(Console.ReadLine());
            int capacity = capacityFromConsole;
            Stack<int> clothes = new Stack<int>();
            int racksCount = 1;
            for (int i = 0; i < cloth.Length; i++)
            {
                clothes.Push(cloth[i]);
            }
            for (int i = 0; i < cloth.Length; i++)
            {
                int element = clothes.Pop();
                if (capacity > element)
                {
                    capacity -= element;
                }
                else if (capacity == element)
                {
                    if (clothes.Count > 0)
                        racksCount++;
                    capacity = capacityFromConsole;
                }
                else if (capacity < element)
                {
                    racksCount++;
                    capacity = capacityFromConsole - element;
                }
            }
            Console.WriteLine(racksCount);
        }
    }
}

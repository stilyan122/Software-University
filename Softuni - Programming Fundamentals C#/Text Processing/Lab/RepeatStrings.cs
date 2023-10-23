using System;
using System.Linq;

namespace RepeatStrings
{
    class RepeatStrings
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            foreach (var item in input)
            {
                for (int i = 0; i < item.Length; i++)
                {
                    Console.Write(item);
                }
            }
            Console.WriteLine();
        }
    }
}

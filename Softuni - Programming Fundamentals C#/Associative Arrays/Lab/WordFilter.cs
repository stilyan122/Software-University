using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFilter
{
    class WordFilter
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] filtered = input.Where(x => x.Length % 2 == 0).ToArray();
            foreach (var word in filtered)
            {
                Console.WriteLine(word);
            }
        }
    }
}

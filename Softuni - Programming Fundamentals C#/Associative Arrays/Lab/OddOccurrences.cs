using System;
using System.Collections.Generic;
using System.Linq;

namespace OddOccurrences
{
    class OddOccurrences
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> occ = new Dictionary<string, int>();
            foreach (var item in input)
            {
                string word = item.ToLower();
                if (!occ.ContainsKey(word))
                {
                    occ.Add(word, 1);
                }
                else
                {
                    occ[word]++;
                }
            }
            List<string> output = new List<string>();
            foreach (var item in occ)
            {
                if (item.Value%2==1)
                {
                    output.Add(item.Key);
                }
            }
            Console.WriteLine(string.Join(" ",output));
        }
    }
}

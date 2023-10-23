using System;
using System.Linq;

namespace CountUppercaseWords
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            string[] input =
                Console
                .ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Where(x=>x.StartsWith(x[0].ToString().ToUpper()))
                .ToArray();
            foreach (var word in input)
            {
                Console.WriteLine(word);
            }
        }
    }
}

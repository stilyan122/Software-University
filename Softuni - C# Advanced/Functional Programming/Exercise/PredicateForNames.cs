using System;

namespace PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Predicate<string> length = name => name.Length <= n;
            foreach (var name in names)
            {
                if (length(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}

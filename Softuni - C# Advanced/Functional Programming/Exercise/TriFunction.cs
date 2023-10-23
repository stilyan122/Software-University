using System;

namespace TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> sum = (name, n) =>
            {
                int sum = 0;
                foreach (var character in name)
                {
                    sum += (int)character;
                }
                if (sum >= n)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };
            Func<Func<string, int, bool>, string, int, bool> print = (func, name, n) =>
                 {
                     if (func(name, n))
                     {
                         Console.WriteLine(name);
                         return true;
                     }
                     else
                     {
                         return false;
                     }
                 };
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in names)
            {
                if (print(sum, name, n))
                {
                    break;
                }
            }
        }
    }
}


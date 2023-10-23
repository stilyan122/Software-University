using System;
namespace ActionPrint
{
    class ActionPrint
    {
        static void Main(string[] args)
        {
            Action<string> print = name => Console.WriteLine(name);
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in input)
            {
                print(name);
            }
        }
    }
}

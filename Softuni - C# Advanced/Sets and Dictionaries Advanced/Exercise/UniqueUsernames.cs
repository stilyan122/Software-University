using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class UniqueUsernames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> usernames = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                usernames.Add(name);
            }
            foreach (var item in usernames)
            {
                Console.WriteLine(item);
            }
        }
    }
}

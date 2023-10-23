using System;
using System.Linq;
using System.Collections.Generic;

namespace TheVLogger
{
    class TheVLogger
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> followers = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            string input = Console.ReadLine();
            while (input != "Statistics")
            {
                string[] data = input.Split();
                string vlogger = data[0];
                string command = data[1];
                if (command == "joined")
                {
                    if (followers.ContainsKey(vlogger) == false)
                    {
                        followers.Add(vlogger, new Dictionary<string, HashSet<string>>());
                        followers[vlogger].Add("followers", new HashSet<string>());
                        followers[vlogger].Add("following", new HashSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string member = data[2];

                    if (vlogger != member && followers.ContainsKey(vlogger) && followers.ContainsKey(member))
                    {
                        followers[vlogger]["following"].Add(member);
                        followers[member]["followers"].Add(vlogger);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {followers.Count} vloggers in its logs.");
            int number = 1;
            foreach (var vlogger in followers.OrderByDescending(v => v.Value["followers"].Count).ThenBy(v => v.Value["following"].Count))
            {
                Console.WriteLine($"{number}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
                if (number == 1)
                {
                    foreach (string follower in vlogger.Value["followers"].OrderBy(f => f))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                number++;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] str = input.Split(':');
                string contest = str[0];
                string password = str[1];
                contests.Add(contest, password);
                input = Console.ReadLine();
            }
            string inputCollection = Console.ReadLine();
            while (inputCollection != "end of submissions")
            {
                string[] str2 = inputCollection.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contestFromCollection = str2[0];
                string passwordFromCollection = str2[1];
                string nameCollection = str2[2];
                int pointFromCollection = int.Parse(str2[3]);
                if (contests.ContainsKey(contestFromCollection)
                    && contests.ContainsValue(passwordFromCollection))
                {
                    if (users.ContainsKey(nameCollection) == false)
                    {
                        users.Add(nameCollection, new Dictionary<string, int>());
                        users[nameCollection].Add(contestFromCollection, pointFromCollection);
                    }
                    if (users[nameCollection].ContainsKey(contestFromCollection))
                    {
                        if (users[nameCollection][contestFromCollection] < pointFromCollection)
                        {
                            users[nameCollection][contestFromCollection] = pointFromCollection;
                        }
                    }
                    else
                    {
                        users[nameCollection].Add(contestFromCollection, pointFromCollection);
                    }
                }
                inputCollection = Console.ReadLine();
            }
            Dictionary<string, int> usernameTotalPoints = new Dictionary<string, int>();
            foreach (var kvp in users)
            {
                usernameTotalPoints[kvp.Key] = kvp.Value.Values.Sum();
            }
            string bestName = usernameTotalPoints.Keys.Max();
            int bestPoints = usernameTotalPoints.Values.Max();
            foreach (var kvp in usernameTotalPoints)
            {
                if (kvp.Value == bestPoints)
                {
                    Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value} points.");

                }
            }
            Console.WriteLine("Ranking:");
            foreach (var name in users)
            {
                Dictionary<string, int> dict = name.Value;
                dict = dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                Console.WriteLine("{0}", name.Key);
                foreach (var kvp in dict)
                {
                    Console.WriteLine("#  {0} -> {1}", kvp.Key, kvp.Value);
                }
            }
        }
    }
}

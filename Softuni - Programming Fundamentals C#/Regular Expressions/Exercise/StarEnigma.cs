using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace StarEnigma
{
    class StarEnigma
    {
        static void Main(string[] args)
        {
            string pattern = @"[SsTtAaRr]";
            List<string> attackedPlanets = new List<string>();
            int attackCounter = 0;
            List<string> destroyedPlanets = new List<string>();
            int destroyCounter = 0;
            Regex regexSTAR = new Regex(pattern);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                MatchCollection characters = regexSTAR.Matches(input);
                int count = characters.Count;
                StringBuilder decrypted = new StringBuilder();
                for (int j = 0; j < input.Length; j++)
                {
                    decrypted.Append((char)(input[j]-count));
                }
                string planetPattern = @"(([^@\-!:>@]*)@(?<name>[A-Za-z]+)([^@\-!:>A-Za-z]*)([^@\-!:>@]*):([^@\-!:>@]*)\d+\!([^@\-!:>@]*)(?<status>(A|D))([^@\-!:>@]*)\!([^@\-!:>@]*)\-\>([^@\-!:>@]*)\d+[^@\-!:>0-9]*)\b";
                Regex planetRegex = new Regex(planetPattern);
                if (planetRegex.IsMatch(decrypted.ToString()))
                {
                    Match planet = planetRegex.Match(decrypted.ToString());
                    string name = planet.Groups["name"].Value;
                    string status = planet.Groups["status"].Value;
                    if (status=="A")
                    {
                        attackedPlanets.Add(name);
                        attackCounter++;
                    }
                    else
                    {
                        destroyedPlanets.Add(name);
                        destroyCounter++;
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {attackCounter}");
            foreach (var attack in attackedPlanets.OrderBy(x=>x))
            {
                Console.WriteLine($"-> {attack}");
            }
            Console.WriteLine($"Destroyed planets: {destroyCounter}");
            foreach (var destroy in destroyedPlanets.OrderBy(x=>x))
            {
                Console.WriteLine($"-> {destroy}");
            }
        }
    }
}

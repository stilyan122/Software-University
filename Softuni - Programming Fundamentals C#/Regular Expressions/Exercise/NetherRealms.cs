using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class NetherRealms
    {
        static void Main(string[] args)
        {
            string[] input = Regex.Split(Console.ReadLine(), @" *,{1} *");
            Regex healthRegex = new Regex(@"[^+\-*/.\d]");
            Regex damageRegex = new Regex(@"((|-)\d+\.\d+|(|-)\d+)");
            Dictionary<string, KeyValuePair<int, double>> demons = new Dictionary<string, KeyValuePair<int, double>>();
            foreach (var demon in input.OrderBy(x => x))
            {
                int health = 0;
                double damage = 0.0;
                Match[] chars = healthRegex.Matches(demon).ToArray();
                foreach (var curr in chars)
                {
                    health += char.Parse(curr.Value);
                }
                Match[] nums = damageRegex.Matches(demon).ToArray();
                foreach (var number in nums)
                {
                    damage += double.Parse(number.Value);
                }
                Match[] symbols = Regex.Matches(demon, @"[\*\/]").ToArray();
                foreach (var symbol in symbols)
                {
                    if (symbol.Value == "*")
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }
                demons[demon] = new KeyValuePair<int, double>(health, damage);
            }
            foreach (var demon in demons)
            {
                Console.WriteLine($"{demon.Key} - {demon.Value.Key} health, {demon.Value.Value:F2} damage");
            }
        }
    }
}

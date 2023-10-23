using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> raid = new List<BaseHero>();
            int counter = 0;
            while (counter<n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                switch (type)
                {
                    case "Druid":
                        Druid druid = new Druid(name);
                        raid.Add(druid);
                        counter++;
                        break;
                    case "Paladin":
                        Paladin paladin = new Paladin(name);
                        raid.Add(paladin);
                        counter++;
                        break;
                    case "Warrior":
                        Warrior warrior = new Warrior(name);
                        raid.Add(warrior);
                        counter++;
                        break;
                    case "Rogue":
                        Rogue rogue = new Rogue(name);
                        raid.Add(rogue);
                        counter++;
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            int sum = 0;
            foreach (BaseHero hero in raid)
            {
                sum += hero.Power;
                Console.WriteLine(hero.CastAbility());
            }
            if (sum>=bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}

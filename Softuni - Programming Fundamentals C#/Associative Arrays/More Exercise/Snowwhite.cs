using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowwhite
{
    class Snowwhite
    {
        static void Main(string[] args)
        {
            string command = "";
            List<Dwarf> dwarfs = new List<Dwarf>();
            while ((command = Console.ReadLine()) != "Once upon a time")
            {
                string[] info = command.Split(" <:> ").ToArray();
                string name = info[0];
                string hatColor = info[1];
                int physics = int.Parse(info[2]);
                Dwarf dwarf = new Dwarf(name, hatColor, physics);
                bool isMatched = false;

                for (int i = 0; i < dwarfs.Count; i++)
                {
                    if (dwarfs[i].Name == name)
                    {
                        isMatched = true;
                        if (dwarfs[i].HatColor != hatColor)
                        {
                            dwarfs.Add(dwarf);
                        }
                        else if (dwarfs[i].Physics < physics)
                        {
                            dwarfs[i].Physics = physics;
                        }
                        break;
                    }
                }
                if (!isMatched)
                {
                    dwarfs.Add(dwarf);
                }
            }
            Dictionary<string, int> colors = new Dictionary<string, int>();
            for (int i = 0; i < dwarfs.Count; i++)
            {
                if (!colors.ContainsKey(dwarfs[i].HatColor))
                {
                    colors.Add(dwarfs[i].HatColor, 0);
                }
                colors[dwarfs[i].HatColor] += 1;
            }
            colors = colors.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            List<Dwarf> sortedDwarfs = new List<Dwarf>();
            foreach (var color in colors.Keys)
            {
                for (int i = 0; i < dwarfs.Count; i++)
                {
                    if (dwarfs[i].HatColor == color)
                    {
                        sortedDwarfs.Add(dwarfs[i]);
                    }
                }
            }
            sortedDwarfs = sortedDwarfs.OrderByDescending(x => x.Physics).ToList();
            foreach (var item in sortedDwarfs)
            {
                Console.WriteLine($"({item.HatColor}) {item.Name} <-> {item.Physics}");
            }
        }
    }

}
    public class Dwarf
    {
        public Dwarf(string name, string hatColor, int physics)
        {
            Name = name;
            HatColor = hatColor;
            Physics = physics;
        }
        public string Name { get; set; }
        public string HatColor { get; set; }
        public int Physics { get; set; }

    }

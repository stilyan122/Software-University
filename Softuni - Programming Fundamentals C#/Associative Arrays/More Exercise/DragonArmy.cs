using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonArmy
{
    class DragonArmy
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Dragon> dragons = new List<Dragon>();

            for (int i = 0; i < n; i++)
            {
                string[]input = Console.ReadLine().Split(' ');
                double value = 0;

                Dragon dragon = new Dragon()
                {
                    Type = input[0],
                    Name = input[1],
                    Damage = double.TryParse(input[2], out value) ? value : 45,
                    Health = double.TryParse(input[3], out value) ? value : 250,
                    Armour = double.TryParse(input[4], out value) ? value : 10,
                };

                Dragon existingDragon = dragons.SingleOrDefault(d => d.Name == dragon.Name && d.Type == dragon.Type);
                if (existingDragon != null)
                {
                    existingDragon.Damage = dragon.Damage;
                    existingDragon.Health = dragon.Health;
                    existingDragon.Armour = dragon.Armour;
                }
                else
                {
                    dragons.Add(dragon);
                }
            }
            var groupedDragons = dragons.GroupBy(
                d => d.Type,
                d => d,
                (key, d) =>
                    new Dragons()
                    {
                        Type = key,
                        DragonsList = d.ToList()
                    });

            foreach (var groupedDragon in groupedDragons)
            {
                int dragonCount = groupedDragon.DragonsList.Count;
                double damage = groupedDragon.DragonsList.Sum(d => d.Damage) / dragonCount;
                double health = groupedDragon.DragonsList.Sum(d => d.Health) / dragonCount;
                double armour = groupedDragon.DragonsList.Sum(d => d.Armour) / dragonCount;

                Console.WriteLine($"{groupedDragon.Type}::({damage:F2}/{health:F2}/{armour:F2})");

                foreach (Dragon dragon in groupedDragon.DragonsList.OrderBy(d => d.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armour}");
                }
            }
        }
    }

    class Dragon
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public double Damage { get; set; }
        public double Health { get; set; }
        public double Armour { get; set; }
    }

    class Dragons
    {
        public string Type { get; set; }
        public List<Dragon> DragonsList { get; set; }
    }
}

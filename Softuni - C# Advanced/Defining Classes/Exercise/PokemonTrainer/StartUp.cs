using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string inputCommand = Console.ReadLine();
            List<Trainer> trainers = new List<Trainer>();
            while (inputCommand != "Tournament")
            {
                string[] input = inputCommand.Split(" ",
                    StringSplitOptions.RemoveEmptyEntries);
                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (trainers.Find(x=>x.Name==trainerName)!=default)
                {
                    trainers.Find(x => x.Name == trainerName).Pokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }
                inputCommand = Console.ReadLine();
            }
            string command = Console.ReadLine();
            while (command!="End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Find(x=>x.Element==command)!=default)
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(x => x.Health -= 10);
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            if (trainer.Pokemons[i].Health<=0)
                            {
                                trainer.Pokemons.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
                command = Console.ReadLine();
            }
            trainers = trainers.OrderByDescending(x => x.Badges).ToList();
            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}

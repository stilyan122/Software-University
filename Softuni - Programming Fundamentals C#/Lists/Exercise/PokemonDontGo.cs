using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGo
{
    class PokemonDontGo
    {
        static void Main(string[] args)
        {
            List<int> removedElements = new List<int>();
            List<int> distances = Console.ReadLine().Split().Select(int.Parse).ToList();
            while (distances.Count>0)
            {
                int removed = 0;
                int index = int.Parse(Console.ReadLine());
                if (index<0)
                {
                    index = 0;
                    removed = distances[index];
                    distances.RemoveAt(index);
                    int lastElement = distances.Last();
                    distances.Insert(0, lastElement);
                }
                else if (index>=distances.Count)
                {
                    index = distances.Count - 1;
                    removed = distances[index];
                    distances.RemoveAt(index);
                    int firstElement = distances.First();
                    distances.Insert(distances.Count, firstElement);
                }
                else
                {
                    removed = distances[index];
                    distances.RemoveAt(index);
                }
                removedElements.Add(removed);
                for (int i = 0; i < distances.Count; i++)
                {
                    if (distances[i]<=removed)
                    {
                        distances[i] += removed;
                    }
                    else
                    {
                        distances[i] -= removed;
                    }
                }
            }
            Console.WriteLine(removedElements.Sum());
        }
    }
}

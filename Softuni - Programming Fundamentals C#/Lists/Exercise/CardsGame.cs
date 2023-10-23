using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class CardsGame
    {
        static void Main()
        {
            List<int> hand1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> hand2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            int counter = 0;
            while (hand1.Count>0&&hand2.Count>0)
            {
                int current1 = hand1[counter];
                int current2 = hand2[counter];
                if (current1>current2)
                {
                    hand2.Remove(current2);
                    hand1.Remove(current1);
                    hand1.Add(current2);
                    hand1.Add(current1);
                }
                else if (current1<current2)
                {
                    hand2.Remove(current2);
                    hand1.Remove(current1);
                    hand2.Add(current1);
                    hand2.Add(current2);
                }
                else
                {
                    hand2.Remove(current2);
                    hand1.Remove(current1);
                }
            }
            if (hand1.Count>0&&hand2.Count==0)
            {
                Console.WriteLine($"First player wins! Sum: {hand1.Sum()}");
            }
            else if(hand1.Count == 0 && hand2.Count > 0)
            {
                Console.WriteLine($"Second player wins! Sum: {hand2.Sum()}");
            }
        }
    }
}

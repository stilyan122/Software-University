using System;
using System.Collections.Generic;
using System.Linq;

namespace BombNumbers
{
    class BombNumbers
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bomb = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int num = bomb[0];
            int power = bomb[1];
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i]==num)
                {
                    int start = i - power;
                    if (start<0)
                    {
                        start = 0;
                    }
                    int finish = i + power + 1;
                    if (finish>input.Count)
                    {
                        finish = input.Count;
                    }
                    for (int j = start; j < finish; j++)
                    {
                        input.RemoveAt(start);
                    }
                    i--;
                } 
            }
            Console.WriteLine(input.Sum());
        }
    }
}

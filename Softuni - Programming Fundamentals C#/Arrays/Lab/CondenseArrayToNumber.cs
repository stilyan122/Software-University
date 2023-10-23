using System;
using System.Linq;

namespace CondenseArrayToNumber
{
    class CondenseArrayToNumber
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] condensed = new int[input.Length - 1];

            if (input.Length == 1)
            {
                Console.WriteLine(input[0]);
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < condensed.Length - i; j++)
                {
                    condensed[j] = input[j] + input[j + 1];
                }
                input = condensed;
            }
            Console.WriteLine(condensed[0]);
        }
    }
}

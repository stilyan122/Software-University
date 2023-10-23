using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TakeSkipRope
{
    class TakeSkipRope
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> numbers = new List<int>();
            List<string> nonNumbers = new List<string>();
            List<int> evens = new List<int>();
            List<int> odds = new List<int>();
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    numbers.Add(input[i]-48);
                }
                else
                {
                    nonNumbers.Add(input[i].ToString());
                }
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i%2==0)
                {
                    evens.Add(numbers[i]);
                }
                else
                {
                    odds.Add(numbers[i]);
                }
            }
            for (int i = 0; i < odds.Count; i++)
            {
                int currTake = evens[i];
                int currSkip = odds[i];
                for (int j = 0; j < currTake; j++)
                {
                    if (j >= nonNumbers.Count)
                    {
                        break;
                    }
                    output.Append(nonNumbers[j]);
                }
                nonNumbers = nonNumbers.Skip(currTake).ToList();
                nonNumbers = nonNumbers.Skip(currSkip).ToList();
            }
            Console.WriteLine(output.ToString());
        }
    }
}

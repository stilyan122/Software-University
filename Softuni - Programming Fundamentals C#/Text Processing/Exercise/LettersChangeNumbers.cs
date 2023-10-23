using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace LettersChangeNumbers
{
    class LettersChangeNumbers
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            List<decimal> sums = new List<decimal>();
            decimal totalSum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                string curr = numbers[i];
                char letter1 = curr[0];
                char letter2 = curr[curr.Length - 1];
                StringBuilder str = new StringBuilder();
                for (int j = 1; j < curr.Length - 1; j++)
                {
                    str.Append(curr[j]);
                }
                decimal num = decimal.Parse(str.ToString());
                if (letter1.ToString() == letter1.ToString().ToUpper())
                {
                    num /= (int)(letter1) - 64;
                }
                else
                {
                    num *= (int)(letter1) - 96;
                }
                if (letter2.ToString() == letter2.ToString().ToUpper())
                {
                    num -= (int)(letter2) - 64;
                }
                else
                {
                    num += (int)(letter2) - 96;
                }
                sums.Add(num);
            }
            foreach (var sum in sums)
            {
                totalSum += sum;
            }
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}

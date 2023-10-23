using System;
using System.Linq;

namespace StringExplosion
{
    class StringExplosion
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>' && i+1<input.Length && char.IsDigit(input[i+1]))
                {
                    int power = (int)(input[i + 1] - 48);
                    int counter = i+1;
                    while (power > 0 && counter<input.Length)
                    { 
                        if (input[counter] != '>')
                        {
                            input = input.Remove(counter, 1);
                            power--;
                        }
                        else
                        {
                            power += (int)(input[counter + 1] - 48);
                            counter++;
                            input = input.Remove(counter, 1);
                            power--;
                        }
                        i = counter-1;
                    }
                }
            }
            Console.WriteLine(input);
        }
    }
}

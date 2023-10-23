using System;
using System.Collections.Generic;
using System.Linq;

namespace EnterNumbers
{
    public class EnterNumbers
    {
        static void Main(string[] args)
        {
            ReadNumber(1, 100);
        }

        static void ReadNumber(int start, int end)
        {
            List<int> nums = new List<int>();
            while (nums.Count < 10)
            {
                string n1 = Console.ReadLine();
                try
                {
                    int n = int.Parse(n1);

                    if (n <= start || n >= end)
                    {
                        throw new ArgumentException($"Your number is not in range {start} - 100!");
                    }

                    else
                    {
                        nums.Add(n);
                        start = n;
                    }
                }
                catch (ArgumentException ar)
                {
                    Console.WriteLine(ar.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Invalid Number!");
                }
            }
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}

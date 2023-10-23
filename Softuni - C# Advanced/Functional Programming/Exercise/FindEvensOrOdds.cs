using System;
using System.Linq;

namespace FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            Predicate<double> evens = (number) => number%2==0 || number%2==-0;
            Predicate<double> odds = (number) => number%2==1 || number%2==-1;
            int[] coords = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string word = Console.ReadLine();
            if (coords[0] < coords[1])
            {
                if (word == "odd")
                {
                    for (int i = coords[0]; i <= coords[1]; i++)
                    {
                        if (odds(i))
                        {
                            if(i<coords[1])
                            Console.Write(i + " ");
                            else
                            Console.WriteLine(i);
                        }
                    }
                }
                else if (word == "even")
                {
                    for (int i = coords[0]; i <= coords[1]; i++)
                    {
                        if (evens(i))
                        {
                            if (i < coords[1])
                                Console.Write(i + " ");
                            else
                                Console.WriteLine(i);
                        }
                    }
                }
            }
            else
            {
                if (word == "odd")
                {
                    for (int i = coords[1]; i <= coords[0]; i++)
                    {
                        if (odds(i))
                        {
                            if (i < coords[0])
                                Console.Write(i + " ");
                            else
                                Console.WriteLine(i);
                        }
                    }
                }
                else if (word == "even")
                {
                    for (int i = coords[1]; i <= coords[0]; i++)
                    {
                        if (evens(i))
                        {
                            if (i < coords[0])
                                Console.Write(i + " ");
                            else
                                Console.WriteLine(i);
                        }
                    }
                }
            }
        }
    }
}

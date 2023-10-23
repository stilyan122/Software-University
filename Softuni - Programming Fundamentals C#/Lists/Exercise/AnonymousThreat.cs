using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousThreat
{
    class AnonymousThreat
    {
        static void Main()
        {
            List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            while (command[0]!="3:1")
            {
                if (command[0]=="merge")
                {
                    int startI = int.Parse(command[1]);
                    if (startI<0)
                    {
                        startI = 0;
                    }
                    startI++;
                    int endI = int.Parse(command[2]);
                    if (endI>=input.Count)
                    {
                        endI = input.Count - 1;
                    }
                    for (int i = startI; i <= endI; i++)
                    {
                        input[startI-1] += input[startI];
                        input.RemoveAt(startI);
                    }
                }
                else if (command[0]=="divide")
                {
                    int startI = int.Parse(command[1]);
                    int count = int.Parse(command[2]);
                    string curr = input[startI];
                    decimal countForPieces = ((decimal)(curr.Length / count));
                    decimal rest = (decimal)(input[startI].Length - count * countForPieces);
                    input.RemoveAt(startI);
                    List<string> substrings = new List<string>();
                    if (countForPieces % 2 == 0 && rest==0)
                    {
                        while (curr.Length > 0)
                        {
                            string subStr = curr.Substring(0, (int)countForPieces);
                            substrings.Add(subStr);
                            curr = curr.Remove(0, (int)countForPieces);
                        }
                    }
                    else
                    {
                        while (curr.Length > 0)
                        {
                            if (curr.Length == rest)
                            {
                                for (int i = 0; i < rest; i++)
                                {
                                    substrings[substrings.Count - 1] += curr[i];
                                }
                                break;
                            }
                            string subStr = curr.Substring(0, (int)countForPieces);
                            substrings.Add(subStr);
                            curr = curr.Remove(0, (int)countForPieces);
                        }
                    }
                    for (int i = 0; i < substrings.Count; i++)
                    {
                        input.Insert(startI,substrings[i]);
                        startI++;
                    }
                }   
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine(string.Join(" ",input));
        }
    }
}

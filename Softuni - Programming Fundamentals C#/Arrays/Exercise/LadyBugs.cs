using System;
using System.Linq;

namespace LadyBugs
{
    class LadyBugs
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            bool[] fields = new bool[size];
            int[] indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            foreach (var index in indexes)
            {
                if (index < 0 || index >= fields.Length)
                {
                    continue;
                }
                fields[index] = true;

            }
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }
                string[] parts = line.Split();
                int index = int.Parse(parts[0]);
                string direction = parts[1];
                int lenght = int.Parse(parts[2]);
                if (index < 0 || index >= fields.Length || !fields[index])
                {
                    continue;
                }
                fields[index] = false;
                while (true)
                {
                    if (direction == "right")
                    {
                        index += lenght;
                    }
                    else
                    {
                        index -= lenght;
                    }
                    if (index >= fields.Length || index < 0)
                    {
                        break;
                    }
                    if (!fields[index])
                    {
                        fields[index] = true;
                        break;
                    }
                }
            }
            foreach (var cell in fields)
            {
                if (cell)
                {
                    Console.Write("1 ");
                }
                else { Console.Write("0 "); }
            }
        }
    }
}
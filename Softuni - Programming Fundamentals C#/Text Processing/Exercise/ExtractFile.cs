using System;
using System.Linq;

namespace ExtractFile
{
    class ExtractFile
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("\\");
            string[] file = input[input.Length - 1].Split(".");
            string name = file[0];
            string extension = file[1];
            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}

using System;
using System.Linq;
namespace Largest3Numbers
{
    class Largest3Numbers
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray()
               .OrderByDescending(n => n).ToArray();
            if (arr.Length == 1)
            {
                Console.WriteLine(arr[0]);
            }
            else if (arr.Length == 2)
            {
                Console.Write(arr[0] + " " + arr[1]);
            }
            else
            {
                Console.WriteLine(arr[0] + " " + arr[1] + " " + arr[2]);
            }
        }
    }
}

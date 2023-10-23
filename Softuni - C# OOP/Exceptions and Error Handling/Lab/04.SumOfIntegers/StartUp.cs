using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int sum = 0;
            string word = "";
            string[] arr = Console.ReadLine().Split();
            for (int i = 0; i < arr.Length; i++)
            {
                try
                {
                    string element = arr[i];
                    word = element.ToString();
                    int el = int.Parse(element);

                    sum += el;
                    Console.WriteLine($"Element '{el}' processed - current sum: {sum}");


                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{word}' is in wrong format!");
                    Console.WriteLine($"Element '{word}' processed - current sum: {sum}");

                }
                catch (OverflowException)
                {

                    Console.WriteLine($"The element '{word}' is out of range!");
                    Console.WriteLine($"Element '{word}' processed - current sum: {sum}");


                }
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        
        }
    }
}

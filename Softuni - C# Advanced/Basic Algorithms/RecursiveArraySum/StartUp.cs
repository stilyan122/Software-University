using System;
using System.Linq;

namespace RecursiveArraySum
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double Sum(double[] array,double sum,int counter)
            {
                if (counter == array.Length)
                {
                    return sum;
                }
                sum += array[counter];
                counter++;
                return Sum(array, sum, counter);
            }
            double[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            double sum = Sum(arr, 0, 0);
            Console.WriteLine(sum);
        }
    }
}

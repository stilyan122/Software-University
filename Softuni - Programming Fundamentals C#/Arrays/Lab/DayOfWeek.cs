using System;

namespace DayOfWeek
{
    public class DayOfWeek
    {
        static void Main(string[] args)
        {
            string[] arr =
                {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday",
                "Invalid day!"
            };
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Console.WriteLine(arr[0]);
                    break;
                case 2:
                    Console.WriteLine(arr[1]);
                    break;
                case 3:
                    Console.WriteLine(arr[2]);
                    break;
                case 4:
                    Console.WriteLine(arr[3]);
                    break;
                case 5:
                    Console.WriteLine(arr[4]);
                    break;
                case 6:
                    Console.WriteLine(arr[5]);
                    break;
                case 7:
                    Console.WriteLine(arr[6]);
                    break;
                default:
                    Console.WriteLine(arr[7]);
                    break;
            }
        }
    }
}

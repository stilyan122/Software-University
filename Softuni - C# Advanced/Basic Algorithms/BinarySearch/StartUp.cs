using System;
using System.Linq;

namespace BinarySearch
{
    public class StartUp
    {
        static void Main(string[] args) {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(BinarySearch(arr, n));
        }
        private static int BinarySearch(int[] arr, int n)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (arr[mid] == n)
                    return mid;
                if (arr[mid] < n)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1;
        }
    }
}

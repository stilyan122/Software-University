using System;
using System.Linq;
using _03.MinHeap;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        private MinHeap<int> cookies = new MinHeap<int>();

        public int Solve(int minSweetness, int[] cookies)
        {
            var result = 0;

            foreach (var cookie in cookies)
            {
                this.cookies.Add(cookie);
            }

            while (this.cookies.Count > 1 && this.cookies.Peek() < minSweetness)
            {
                var firstCookie = this.cookies.ExtractMin();
                var secondCookie = this.cookies.ExtractMin();

                var combinedCookie = firstCookie + 2 * secondCookie;

                this.cookies.Add(combinedCookie);

                result++;
            }

            if (this.cookies.Peek() < minSweetness)
            {
                return -1;
            }

            return result;
        }
}
}

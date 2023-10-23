using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            long stops = long.Parse(Console.ReadLine());
            Queue<string> myQueue = new Queue<string>();

            for (long i = 0; i < stops; i++)
            {
                myQueue.Enqueue(Console.ReadLine());
            }
            bool canMakeIt = false;
            for (long i = 0; i < stops; i++)
            {
                long fuel = 0;
                foreach (var item in myQueue)
                {
                    fuel += item.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray()[0];
                    fuel -= item.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray()[1];
                    if (fuel < 0)
                    {
                        canMakeIt = false;
                        break;
                    }
                    else
                    {
                        canMakeIt = true;
                    }
                }
                if (canMakeIt)
                {
                    Console.WriteLine(i);
                    return;
                }
                string helper = myQueue.Dequeue();
                myQueue.Enqueue(helper);
            }
        }
    }
}

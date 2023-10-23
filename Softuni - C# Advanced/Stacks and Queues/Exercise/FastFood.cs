using System;
using System.Linq;
using System.Collections.Generic;

namespace FastFood
{
    class FastFood
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] order = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queueOfOrder = new Queue<int>();
            bool empty = false;
            for (int i = 0; i < order.Length; i++)
            {
                queueOfOrder.Enqueue(order[i]);
            }
            Console.WriteLine(queueOfOrder.Max());
            for (int i = 0; i < order.Length; i++)
            {
                if (quantity >= order[i])
                {
                    quantity -= order[i];
                    queueOfOrder.Dequeue();
                }
                else
                {
                    empty = true;
                    Console.WriteLine($"Orders left: {string.Join(" ", queueOfOrder)}");
                    break;
                }
            }
            if (empty == false)
            {
                Console.WriteLine("Orders complete");
            }

        }
    }
}

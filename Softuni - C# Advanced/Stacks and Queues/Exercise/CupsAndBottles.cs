using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class CupsAndBottles
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queueForCupsCapacity = new Queue<int>(cupsCapacity);
            int[] bottleWithWatter = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stackForBottleWithWater = new Stack<int>(bottleWithWatter);
            int wastedWater = 0;
            while (queueForCupsCapacity.Count > 0 && stackForBottleWithWater.Count > 0)
            {
                int currentBottel = stackForBottleWithWater.Peek();
                int currentCupValue = queueForCupsCapacity.Peek();
                if (currentCupValue > currentBottel)
                {
                    int reducedCupValue = currentCupValue - currentBottel; 
                    stackForBottleWithWater.Pop();
                    while (reducedCupValue > 0 && stackForBottleWithWater.Count > 0) 
                    {
                        int nextBottel = stackForBottleWithWater.Peek(); 
                        if (nextBottel > reducedCupValue)
                        {
                            wastedWater = wastedWater + (nextBottel - reducedCupValue); 
                            reducedCupValue -= nextBottel;
                        }
                        else
                        {
                            reducedCupValue -= nextBottel;
                        }
                        stackForBottleWithWater.Pop();
                    }
                    queueForCupsCapacity.Dequeue(); 
                }
                else if (currentBottel >= currentCupValue)
                {
                    wastedWater = wastedWater + (currentBottel - currentCupValue);
                    stackForBottleWithWater.Pop();
                    queueForCupsCapacity.Dequeue();
                }
            }
            if (stackForBottleWithWater.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", stackForBottleWithWater)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else if (queueForCupsCapacity.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", queueForCupsCapacity)}");
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}

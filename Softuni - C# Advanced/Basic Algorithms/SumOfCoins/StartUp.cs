namespace SumOfCoins
{
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                List<int> coins = Console.ReadLine()
               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();
                int sum = int.Parse(Console.ReadLine());
                Dictionary<int, int> output = ChooseCoins(coins, sum);
                int total = 0;
                foreach (var item in output)
                {
                    total += item.Value;
                }
                Console.WriteLine($"Number of coins to take: {total}");
                foreach (var item in output)
                {
                    if (item.Value != 0)
                    {
                        Console.WriteLine(item.Value+" coin(s) with value "+item.Key);
                    }
                }
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return;
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            coins = coins.OrderByDescending(x => x).ToList();
            Dictionary<int, int> output = new Dictionary<int, int>();
            for (int i = 0; i < coins.Count; i++)
            {
                int item = coins[i];
                output.Add(item, 0);
                while (targetSum - item >= 0)
                {
                    targetSum -= item;
                    output[item]++;
                }

            }
            if (targetSum != 0)
            {
                throw new InvalidOperationException("Error");
            }
            return output;
        }
    }
}
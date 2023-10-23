using System;
using System.Linq;

namespace KaminoFactory
{
    class KaminoFactory
    {
        static void Main(string[] args)
        {
			int n = int.Parse(Console.ReadLine());
			string command = Console.ReadLine();
			int maxOnes = int.MinValue;
			int maxSequence = int.MinValue;
			int sequenceCounter = 0;
			int minStarter = int.MaxValue;
			int bestSequence = 0;
			string strongestSequence = string.Empty;

			while (command != "Clone them!")
			{
				sequenceCounter++;
				int[] sequence = command.Split('!', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
				int counterOnes = 0;
				int counterSequence = 0;
				int sequenceStarter = 0;

				for (int i = 0; i < n - 1; i++)
				{
					if (sequence[i] == 1 && sequence[i + 1] == 1)
					{
						if (counterSequence == 0)
						{
							sequenceStarter = i;
						}
						counterSequence++;
					}
				}
				foreach (int one in sequence)
				{
					if (one == 1)
					{
						counterOnes++;
					}
				}
				if (counterSequence > maxSequence || (sequenceStarter < minStarter && counterSequence >= maxSequence) || (sequenceStarter == minStarter && counterSequence >= maxSequence && counterOnes > maxOnes))
				{
					maxOnes = counterOnes;
					maxSequence = counterSequence;
					minStarter = sequenceStarter;
					bestSequence = sequenceCounter;
					strongestSequence = string.Join(" ", sequence);
				}
				command = Console.ReadLine();
			}
			Console.WriteLine($"Best DNA sample {bestSequence} with sum: {maxOnes}.");
			Console.WriteLine($"{strongestSequence}");
	    }
    }
}

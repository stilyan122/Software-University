namespace SetCover
{
    using System.Collections.Generic;
    using System;
    using System.Linq;
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] universe = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());
            int[][] sets = new int[n][];
            for (int row = 0; row < sets.Length; row++)
            {
                sets[row] = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            }
            List<int[]> selectedSets = ChooseSets(sets, universe);
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (var set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            List<int[]> output = new List<int[]>();
            while (universe.Count > 0)
            {
                int[] longest = sets.OrderByDescending(s => s.Count(x => universe.Contains(x))).FirstOrDefault();
                output.Add(longest);
                sets = sets.Where(s => s != longest).ToArray();
                universe = universe.Where(e => !longest.Contains(e)).ToArray();
            }
            return output;
        }
    }
}

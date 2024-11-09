namespace _5_6_7Ex
{
    public class StartUp
    {
        static void Main()
        {
            // TODO: Invoke a method by your own choice.
        }

        // Ex.5
        public static void ReverseNumbersWithAStack()
        {
            int[] numbers = Console.ReadLine()?
                                    .Split(' ')?
                                    .Select(int.Parse)?
                                    .ToArray() ?? [1,2,3];

            Stack<int> stack = new Stack<int>();

            foreach (int number in numbers)
            {
                stack.Push(number);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }

            Console.WriteLine();
        }

        // Ex.6
        public static void CalculateSequenceWithAQueue()
        {
            int N = int.Parse(Console.ReadLine() ?? "1");

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(N);

            List<int> sequence = new List<int>();

            while (sequence.Count < 50)
            {
                int current = queue.Dequeue();

                sequence.Add(current);

                queue.Enqueue(current + 1);       
                queue.Enqueue(2 * current + 1);   
                queue.Enqueue(current + 2);       
            }

            Console.WriteLine(string.Join(", ", sequence));
        }

        // Ex.7
        public static void SequenceN_M()
        {
            var input = Console.ReadLine()?
                .Split(' ')?
                .Select(int.Parse)?
                .ToList() ?? [5, 10];

            var n = input.First();
            var m = input.Last();

            Queue<Item> queue = new Queue<Item>();
            HashSet<int> visited = new HashSet<int>();
            var list = new List<Item>();
            queue.Enqueue(new Item(n, null));
            visited.Add(n);

            while (queue.Count > 0)
            {
                Item current = queue.Dequeue();

                if (current.Value == m)
                {
                    list.Add(current);
                    PrintSolution(current);
                }

                int[] nextValues = { current.Value + 1, current.Value + 2, current.Value * 2 };

                foreach (var nextValue in nextValues)
                {
                    if (!visited.Contains(nextValue) && nextValue <= m)
                    {
                        queue.Enqueue(new Item(nextValue, current));
                        visited.Add(nextValue);
                    }
                }
            }

            Console.WriteLine("(no solution)");
        }

        public class Item
        {
            public int Value { get; set; }
            public Item Previous { get; set; }

            public Item(int value, Item previous)
            {
                this.Value = value;
                this.Previous = previous;
            }
        }

        private static void PrintSolution(Item item)
        {
            Stack<int> sequence = new Stack<int>();

            while (item != null)
            {
                sequence.Push(item.Value);
                item = item.Previous;
            }

            Console.WriteLine(string.Join(" -> ", sequence));
        }
    }
}
namespace SumEvens
{
    public class SumEvens
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "show")
                {
                    var result = SumAsync();
                    Console.WriteLine(result);
                }
            }
        }

        public static long SumAsync()
        {
            return Task.Run(() =>
            {
                long sum = 0;

                for (int i = 1; i <= 100000; i++)
                {
                    sum += i;
                }

                return sum;
            }).Result;
        }
    }
}

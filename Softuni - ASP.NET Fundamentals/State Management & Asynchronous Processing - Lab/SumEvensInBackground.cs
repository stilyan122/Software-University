namespace SumEvensInBackground
{
    public class Program
    {
        static void Main()
        {
            Exercise();    
        }

        public static async void Exercise()
        {
            string command = Console.ReadLine();

            while (command != "exit")
            {
                if (command == "show")
                {
                    long result = await SumAsync();
                    Console.WriteLine(result);
                }
                command = Console.ReadLine();
            }
        }
        public static async Task<long> SumAsync()
        {
            long sum = 0;
            for (long i = 1; i < 1000000000; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
}

namespace _7.EvenNumbersThread
{
    public class EvenNumbersThread
    {
        static void Main()
        {
            Thread thread = new Thread(thread =>
            {
                long number1 = long.Parse(Console.ReadLine());
                long number2 = long.Parse(Console.ReadLine());

                static void Print(long n1, long n2)
                {
                    for (long i = n1; i <= n2; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.WriteLine(i);
                        }
                    }
                }

                Print(number1, number2);
            });

            thread.Start();
            thread.Join();

            Console.WriteLine("Thread finished work");
        }
    }
}

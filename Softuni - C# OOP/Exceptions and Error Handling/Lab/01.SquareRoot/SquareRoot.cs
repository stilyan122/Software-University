using System;

namespace SquareRoot
{
    public class SquareRoot
    {
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (n<0)
                {
                    throw new InvalidOperationException("Invalid number.");
                }
                else
                {
                    Console.WriteLine(Math.Sqrt(n));
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}

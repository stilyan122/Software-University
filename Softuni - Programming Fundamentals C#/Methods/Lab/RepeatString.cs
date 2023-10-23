using System;
using System.Text;

namespace RepeatString
{
    class RepeatString
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int times = int.Parse(Console.ReadLine());
            string repeated = Repeat(str, times);
            string Repeat(string str,int times)
            {
                StringBuilder repeat = new StringBuilder();
                for (int i = 0; i < times; i++)
                {
                    repeat.Append(str);
                }
                return repeat.ToString().TrimEnd();
            }
            Console.WriteLine(repeated);
        }
    }
}

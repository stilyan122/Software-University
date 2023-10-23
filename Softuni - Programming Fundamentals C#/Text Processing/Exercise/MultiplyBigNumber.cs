using System;
using System.Linq;
using System.Text;

namespace MultiplyBigNumber
{
    class MultiplyBigNumber
    {
        static void Main(string[] args)
        {
            string num1 = Console.ReadLine();
            int num2 = int.Parse(Console.ReadLine());
            StringBuilder product = new StringBuilder();
            int more = 0;
            if (num2 == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                foreach (var item in num1.Reverse())
                {
                    int num = (int)(item) - 48;
                    string multiply = (num2 * num + more).ToString();
                    if (multiply.Length == 1)
                    {
                        product.Append(multiply[0]);
                        more = 0;
                    }
                    else
                    {
                        more = int.Parse(multiply[0].ToString());
                        if (multiply[1] > 0)
                            product.Append(multiply[1]);
                    }
                }
                if (more > 0)
                    product.Append(more);
                Console.WriteLine(string.Join("", product.ToString().Reverse()));
            }
        }
    }
}

using System;
using System.Linq;

namespace ValidUsernames
{
    class ValidUsernames
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            foreach (var item in input)
            {
                if (item.Length>=3&&item.Length<=16)
                {
                    bool isValid = true;
                    foreach (var character in item)
                    {
                        if (!(char.IsDigit(character)||char.IsLetter(character)||character=='-'||character=='_'))
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }
}

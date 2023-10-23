using System;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person = new Person(null, -1);
            Console.WriteLine(Validator.IsValid(person));
        }
    }
}

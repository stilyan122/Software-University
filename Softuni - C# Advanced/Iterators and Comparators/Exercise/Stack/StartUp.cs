using System;

namespace Stack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Stack<string> stack = new Stack<string>();
            while (command.Split(" ",
                StringSplitOptions.RemoveEmptyEntries)[0]!="END")
            {
                switch (command.Split(" ",
                    StringSplitOptions.RemoveEmptyEntries)[0])
                {
                    case "Push":
                        string[] push = command.Substring(5,command.Length-5).Split(", ",
                            StringSplitOptions.RemoveEmptyEntries);;
                        stack.Push(push);
                    break;
                    case "Pop":
                        stack.Pop();
                        break;
                }
                command = Console.ReadLine();
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}

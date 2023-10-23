using System;
using System.Linq;
using System.Collections.Generic;

namespace PredicateParty
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
             List<string> names = Console.ReadLine()
                .Split()
                .ToList();
            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                List<string> data = command.Split().ToList();

                Predicate<string> predicate = GetPredicate(data[1], data[2]);
                switch (data[0])
                {
                    case "Remove":
                        names.RemoveAll(predicate);
                        break;
                    case "Double":
                        {
                            List<string> people = names.FindAll(predicate);
                            if (people.Count > 0)
                            {
                                int index = names.FindIndex(predicate);
                                names.InsertRange(index, people);
                            }
                            break;
                        }
                }
            }
            if (names.Count != 0)
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
        private static Predicate<string> GetPredicate(string commandType, string arg)
        {
            switch (commandType)
            {
                case "StartsWith":
                    return (name) => name.StartsWith(arg);
                case "EndsWith":
                    return (name) => name.EndsWith(arg);
                case "Length":
                    return (name) => name.Length == int.Parse(arg);
                default:
                    throw new ArgumentException();
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace ListyIterator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> iterator = new ListyIterator<string>(new List<string>());
            try
            {
                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] splitted = command.Split(" "
                        , StringSplitOptions.RemoveEmptyEntries);
                    if (splitted[0] == "Create")
                    {
                        if(splitted.Length==1)
                        iterator = new ListyIterator<string>(new List<string>());
                        else
                        {
                            List<string> list = new List<string>();
                            for (int i = 1; i < splitted.Length; i++)
                            {
                                list.Add(splitted[i]);
                            }
                            iterator = new ListyIterator<string>(list);
                        }
                    }
                    else if (splitted[0]=="HasNext")
                    {
                        Console.WriteLine(iterator.HasNext());
                    }
                    else if (splitted[0]=="Move")
                    {
                        Console.WriteLine(iterator.Move());
                    }
                    else if (splitted[0] == "Print")
                    {
                        iterator.Print();
                    }
                    else if (splitted[0] == "PrintAll")
                    {
                        iterator.PrintAll();
                    }
                    command = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

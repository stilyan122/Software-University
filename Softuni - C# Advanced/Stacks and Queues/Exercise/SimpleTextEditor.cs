using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            Stack<string> listOfStrings = new Stack<string>();
            text.Append("");
            listOfStrings.Push(text.ToString());
            text = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                int number = int.Parse(command[0]);
                switch (number)
                {
                    case 1:
                        string toAdd = command[1];
                        text.Append(toAdd);
                        listOfStrings.Push(text.ToString());
                        break;
                    case 2:
                        int count = int.Parse(command[1]);
                        text.Remove(text.Length - count, count);
                        listOfStrings.Push(text.ToString());
                        break;
                    case 3:
                        int index = int.Parse(command[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case 4:
                        string lastOne = listOfStrings.Pop();
                        if (lastOne == text.ToString())
                        {
                            text.Clear();
                            text.Append(listOfStrings.Pop());
                        }
                        else
                        {
                            text.Clear();
                            text.Append(lastOne);
                        }
                        break;
                    default:
                        break;
                }
            }
            }
        }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniCoursePlanning
{
    class SoftUniCoursePlanning
    {
        static void Main(string[] args)
        {
            List<bool> exercises = new List<bool>();
            List<string> schelude = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < schelude.Count; i++)
            {
                if (schelude[i].Contains("-Exercise"))
                {
                    exercises.Add(true);
                }
                else
                {
                    exercises.Add(false);
                }
            }
            string[] command = Console.ReadLine().Split(":");
            while (command[0]!= "course start")
            {
                if (command[0]=="Add")
                {
                    string lessonTitle = command[1];
                    if (!schelude.Contains(lessonTitle))
                    {
                        schelude.Add(lessonTitle);
                        exercises.Add(false);
                    }
                }
                else if (command[0]=="Insert")
                {
                    string lessonTitle = command[1];
                    int index = int.Parse(command[2]);
                    if (!schelude.Contains(lessonTitle))
                    {
                        schelude.Insert(index, lessonTitle);
                        exercises.Insert(index, false);
                    }
                }
                else if (command[0]=="Remove")
                {
                    string lessonTitle = command[1];
                    if (schelude.Contains(lessonTitle))
                    {
                        int index = schelude.IndexOf(lessonTitle);
                        exercises.RemoveAt(index);
                        schelude.Remove(lessonTitle);
                    }
                }
                else if (command[0]=="Swap")
                {
                    string title1 = command[1];
                    string title2 = command[2];

                    if (schelude.Contains(title1) && schelude.Contains(title2) )
                    {
                        int index1 = schelude.IndexOf(title1);
                        int index2 = schelude.IndexOf(title2);
                        string helpIndex1 = schelude[index1];
                        bool helpIndex2 = exercises[index1];
                        exercises[index1] = exercises[index2];
                        exercises[index2] = helpIndex2 ;
                        schelude[index1] = schelude[index2];
                        schelude[index2] = helpIndex1;
                    }
                }
                else if (command[0]=="Exercise")
                {
                    string lessonTitle = command[1];
                    if (schelude.Contains(lessonTitle))
                    {
                        int index = schelude.IndexOf(lessonTitle);
                        if (exercises[index] == false)
                        {
                            exercises[index] = true;
                        }
                    }
                    else
                    {
                        exercises.Add(true);
                        schelude.Add(lessonTitle);
                    }
                }
                command = Console.ReadLine().Split(":");
            }
            int counter = 1;
            for (int i = 0; i < schelude.Count; i++)
            {
                if (exercises[i]==true)
                {
                    Console.WriteLine($"{counter}.{schelude[i]}");
                    counter++;
                    Console.WriteLine($"{counter}.{schelude[i]}-Exercise");
                }
                else
                {
                    Console.WriteLine($"{counter}.{schelude[i]}");
                }
                counter++;
            }
        }
    }
}

namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                StringBuilder builder = new StringBuilder();
                string line = reader.ReadLine();
                int counter = 0;
                while (line!=null)
                {
                    if (counter%2==0)
                    {
                        foreach (var character in line.Split(" ").Reverse())
                        {
                            string replaced = character.Replace(",", "@");
                            replaced = replaced.Replace("-", "@");
                            replaced = replaced.Replace(".", "@");
                            replaced = replaced.Replace("!", "@");
                            replaced = replaced.Replace("?", "@");
                            builder.Append(replaced+" ");
                        }
                        builder.AppendLine();
                    }
                    line = reader.ReadLine();
                    counter++;
                }
                return builder.ToString().Trim();
            }
        }
    }
}

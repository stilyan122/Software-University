using System;
using System.Text;
using System.Collections.Generic;

namespace HTML
{
    class HTML
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();
            List<string> comments = new List<string>();
            string comment = Console.ReadLine();
            while (comment!="end of comments")
            {
                comments.Add(comment);
                comment = Console.ReadLine();
            }
            Console.WriteLine("<h1>");
            Console.WriteLine($"   {title}");
            Console.WriteLine("</h1>");
            Console.WriteLine("<article>");
            Console.WriteLine($"   {content}");
            Console.WriteLine("</article>");
            foreach (var item in comments)
            {
                Console.WriteLine("<div>");
                Console.WriteLine($"   {item}");
                Console.WriteLine("</div>");
            }
        }
    }
}

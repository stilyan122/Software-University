using System;

namespace Articles
{
    class Articles
    {
        static void Main(string[] args)
        {
            string[] articleInput = Console.ReadLine().Split(", ");
            string titleInput = articleInput[0];
            string contentInput = articleInput[1];
            string authorInput = articleInput[2];
            Article article = new Article(titleInput, contentInput, authorInput);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                string type = command[0];
                if (type=="Edit")
                {
                    string content = command[1];
                    article.Edit(content);
                }
                else if (type=="ChangeAuthor")
                {
                    string author = command[1];
                    article.ChangeAuthor(author);
                }
                else if (type=="Rename")
                {
                    string title = command[1];
                    article.Rename(title);
                }
            }
            Console.WriteLine(article.ToString());
        }
    }
    public class Article
    {
        private string title;
        private string content;
        private string author;
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string content)
        {
            this.Content = content;
        }
        public void ChangeAuthor(string author)
        {
            this.Author = author;
        }
        public void Rename(string title)
        {
            this.Title = title;
        }
        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}".ToString(); 
        }
    }
}

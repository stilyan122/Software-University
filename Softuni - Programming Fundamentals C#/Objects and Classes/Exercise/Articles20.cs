using System;
using System.Collections.Generic;

namespace Articles20
{
    class Articles20
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                string[] articleInput = Console.ReadLine().Split(", ");
                string titleInput = articleInput[0];
                string contentInput = articleInput[1];
                string authorInput = articleInput[2];
                Article article = new Article(titleInput, contentInput, authorInput);
                articles.Add(article);
            }
            foreach (var article in articles)
            {
                Console.WriteLine(article.ToString());
            }
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

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}".ToString();
        }
    }
}

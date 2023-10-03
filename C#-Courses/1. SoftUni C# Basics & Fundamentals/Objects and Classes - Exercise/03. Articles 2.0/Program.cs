using System;
using System.Collections.Generic;

namespace _03._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfArticles = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < countOfArticles; i++)
            {
                string[] currArticle = Console.ReadLine().Split(", ");

                Article article = new Article(currArticle[0], currArticle[1], currArticle[2]);

                articles.Add(article);
            }

            string line = Console.ReadLine();

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }


        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }


        public override string ToString()//=> $"{Title} - {Content}: {Author}"; ((=>) е return, Когато имаме един единствен ред само) 
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}

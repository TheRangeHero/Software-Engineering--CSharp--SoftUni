using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] currentArticle = Console.ReadLine().Split(", ");

            Article article = new Article(currentArticle[0], currentArticle[1], currentArticle[2]);

            int countOfChanges = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfChanges; i++)
            {
                string[] lines = Console.ReadLine().Split(": ");
                string command = lines[0];
                string argument = lines[1];

                switch (command)
                {
                    case "Edit":
                        article.Edit(argument);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAutor(argument);
                        break;
                    case "Rename":
                        article.Rename(argument);
                        break;
                }

            }

            Console.WriteLine(article);
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

        public void Edit(string content) => Content = content;
        public void ChangeAutor(string author) => Author = author;
        public void Rename(string title) => Title = title;

        public override string ToString()//=> $"{Title} - {Content}: {Author}"; ((=>) е return, Когато имаме един единствен ред само) 
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}

using System;

namespace _01._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product." };
            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] autors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int countOFMessagesToCreate = int.Parse(Console.ReadLine());

            Random random = new Random();


            for (int i = 0; i < countOFMessagesToCreate; i++)
            {
                string phrase = phrases[random.Next(0, phrases.Length)];
                string curEvent = events[random.Next(0, events.Length)];
                string autor = autors[random.Next(0, autors.Length)];
                string city = cities[random.Next(0, cities.Length)];

                Console.WriteLine($"{phrase} {curEvent} {autor} - {city}");
            }
        }
    }
}

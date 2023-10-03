using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class StartUp
    {
        static void Main(string[] args)
        {

            var peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            var productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            List<Person> people;
            List<Product> products;

            try
            {
                people = SetPeople(peopleInput);
                products = SetProducts(productsInput);
                
                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    try
                    {
                    PrintPurchase(command, people, products);

                    }
                    catch (Exception dido)
                    {

                        Console.WriteLine(dido.Message);
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return;
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }










        public static void PrintPurchase(string command, List<Person> people, List<Product> products)
        {
            var info = command.Split();
            var personName = info[0];
            var productName = info[1];
            var product = products.FirstOrDefault(p => p.Name == productName);

            people.FirstOrDefault(p => p.Name == personName)
                  .BuyProduct(product);
            Console.WriteLine($"{personName} bought {productName}");
        }

        public static List<Person> SetPeople(string[] peopleInput)
        {
            List<Person> people = new List<Person>();

            foreach (var token in peopleInput)
            {
                string[] tokens = token.Split("=", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                double money = double.Parse(tokens[1]);

                Person person = new Person(name, money);

                people.Add(person);

            }
            return people;
        }

        public static List<Product> SetProducts(string[] productsInput)
        {
            List<Product> products = new List<Product>();

            foreach (var token in productsInput)
            {
                var info = token.Split('=', StringSplitOptions.RemoveEmptyEntries);
                var name = info[0];
                var cost = double.Parse(info[1]);

                var product = new Product(name, cost);
                products.Add(product);
            }

            return products;
        }
    }
}

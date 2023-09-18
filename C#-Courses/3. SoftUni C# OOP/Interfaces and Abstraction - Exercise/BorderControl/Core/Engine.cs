namespace BorderControl.Core
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System;


    using Interfaces;
    using IO.Interfaces;

    class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private ICollection<IBuyer> buyers;


        private Engine()
        {
            this.buyers = new Collection<IBuyer>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }



        public void Run()
        {
            this.HandleInput();
            this.CalculatingFood();
            this.PrintResult();
        }

        private void HandleInput()
        {
            int count = int.Parse(this.reader.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var tokens = Console.ReadLine().Split();

                if (tokens.Length == 4)
                {
                    buyers.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
                }
                else if (tokens.Length == 3)
                {
                    buyers.Add(new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }
            }
        }
        private void CalculatingFood()
        {
            string command;

            while ((command = this.reader.ReadLine()) != "End")
            {
                var buyer = buyers.SingleOrDefault(b => b.Name == command);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }
        }
        private void PrintResult()
        {
            this.writer.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}





using System;

namespace Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string comand = Console.ReadLine();


            int studentTickets = 0;
            int standardTickets = 0;
            int kidsTickets = 0;
            double movieTicket = 0;

            while (comand != "Finish")
            {

                int tickets = int.Parse(Console.ReadLine());
                double counter = 0;
                while (counter < tickets)
                {
                    string ticketType = Console.ReadLine();
                    if (ticketType == "End")
                    {
                        break;
                    }

                    if (ticketType == "student")
                    {
                        studentTickets++;
                    }
                    else if (ticketType == "standard")
                    {
                        standardTickets++;
                    }
                    else
                    {
                        kidsTickets++;
                    }
                    counter++;

                }
                movieTicket += counter;
                Console.WriteLine($"{comand} - {counter / tickets * 100:f2}% full.");

                comand = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {movieTicket}\n{studentTickets/ movieTicket*100:f2}% student tickets.\n{standardTickets/ movieTicket*100:f2}% standard tickets.\n{kidsTickets/ movieTicket*100:f2}% kids tickets.");
        }
    }
}

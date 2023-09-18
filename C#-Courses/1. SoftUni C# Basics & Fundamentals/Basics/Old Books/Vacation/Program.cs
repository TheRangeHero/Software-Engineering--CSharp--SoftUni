using System;

public class Program
{

    public static void Main()
    {

        double moneyNeeded = double.Parse(Console.ReadLine());
        double moneyAvailable = double.Parse(Console.ReadLine());

        double money = 0;
        string action = "";

        int spendCounter = 0;
        int daysPast = 0;


        while (moneyAvailable < moneyNeeded)
        {
            action = Console.ReadLine();
            money = double.Parse(Console.ReadLine());
            daysPast++;

            if (action == "save")
            {
                moneyAvailable += money;
                spendCounter = 0;
            }

            else
            {
                moneyAvailable -= money;
                if (moneyAvailable < 0)
                {
                    moneyAvailable = 0;
                }

                spendCounter++;
                if (spendCounter == 5)
                {
                    Console.WriteLine($"You can't save the money.");
                    Console.WriteLine($"{daysPast}");
                    break;
                }
            }
        }
        if (moneyAvailable >= moneyNeeded)
        {
            Console.WriteLine($"You saved the money for {daysPast} days.");
        }
    }

}

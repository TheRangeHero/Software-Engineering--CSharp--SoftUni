using System;

namespace Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int groupCount = int.Parse(Console.ReadLine());

            double Musala = 0;
            double Monblan = 0;
            double Kalimandjaro = 0;
            double K2 = 0;
            double Everest = 0;

            int totalPeople = 0;
            for (int i = 1; i <= groupCount; i++)
            {
                int peopleCount = int.Parse(Console.ReadLine());
                totalPeople += peopleCount;

                if (peopleCount <= 5)
                {
                    Musala += peopleCount;
                }

                else if (peopleCount <= 12)
                {
                    Monblan += peopleCount;
                }

                else if (peopleCount <= 25)
                {
                    Kalimandjaro += peopleCount;
                }

                else if (peopleCount <= 40)
                {
                    K2 += peopleCount;
                }
                else
                {
                    Everest += peopleCount;
                }
            }
                Musala = Musala / totalPeople * 100;
                Monblan = Monblan / totalPeople * 100;
                Kalimandjaro = Kalimandjaro / totalPeople * 100;
                K2 = K2 / totalPeople * 100;
                Everest = Everest / totalPeople * 100;

            Console.WriteLine($"{Musala:F2}% \n{Monblan:F2}% \n{Kalimandjaro:F2}% \n{K2:F2}% \n{Everest:F2}% ");
        }
    }
}

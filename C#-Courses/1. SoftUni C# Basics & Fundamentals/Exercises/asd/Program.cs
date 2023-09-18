using System;

namespace asd
{
    class Program
    {
        static void Main(string[] args)
        {
            double procesorUSD = double.Parse(Console.ReadLine());
            double videoCardUSD = double.Parse(Console.ReadLine());
            double ramUSD = double.Parse(Console.ReadLine());
            int ramCount = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());


            double procesorLV = procesorUSD * 1.57;
            double videoCardLV = videoCardUSD * 1.57;
            double ramLV = ramUSD * 1.57;
            double ramTotal = ramLV * ramCount;

            procesorLV = procesorLV - procesorLV * discount;
            videoCardLV = videoCardLV - videoCardLV * discount;
            

            double total = procesorLV + videoCardLV + ramTotal;



            Console.WriteLine($"Money needed - {total:f2} leva.");


        }
    }
}

using System;
using System.Collections.Generic;


namespace _07._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string inputs = Console.ReadLine();

            while (inputs != "End")
            {

                string[] tokens = inputs.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string companyName = tokens[0];
                string employeID = tokens[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies[companyName] = new List<string>();
                }

                if (companies[companyName].Contains(employeID))
                {
                    inputs = Console.ReadLine();
                    continue;
                }

                companies[companyName].Add(employeID);


                inputs = Console.ReadLine();

            } 

            foreach (var company in companies)
            {
                Console.WriteLine($"{company.Key}");
                foreach (var employeID in company.Value)
                {
                    Console.WriteLine($"-- {employeID}");
                }
            }
        }
    }
}

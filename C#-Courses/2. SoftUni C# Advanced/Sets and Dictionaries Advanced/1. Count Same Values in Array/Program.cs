using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] inputs = Console.ReadLine().Split().Select(n => double.Parse(n)).ToArray();

            Dictionary<double, int> occurances = new Dictionary<double, int>();


            for (int i = 0; i < inputs.Length; i++)
            {
                if (!occurances.ContainsKey(inputs[i]))
                {
                    occurances.Add(inputs[i], 0);
                }

                occurances[inputs[i]]++;
            }


            foreach (var item in occurances)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> stones = Console.ReadLine().
                Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x)).
                ToList();

            Lake lake = new Lake(stones);

            Console.WriteLine(string.Join(", ",lake));
        }
    }
}

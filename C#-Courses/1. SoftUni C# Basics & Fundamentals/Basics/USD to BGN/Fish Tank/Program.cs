﻿using System;

namespace Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
			int length = int.Parse(Console.ReadLine());
			int width = int.Parse(Console.ReadLine());
			int height = int.Parse(Console.ReadLine());
			double percentage = double.Parse(Console.ReadLine());

			int capacity = length * width * height;
			double capacityTransform = capacity * 0.001;
			double water = capacityTransform * (1 - (percentage / 100));

			Console.WriteLine(water);
		}
    }
}

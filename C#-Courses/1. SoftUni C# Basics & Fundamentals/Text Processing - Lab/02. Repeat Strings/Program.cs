﻿using System;

namespace _5._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            string result = string.Empty;
            foreach (string word in words)
            {

                for (int i = 0; i < word.Length; i++)
                {
                    result += word;
                }

            }

            Console.WriteLine(result);
        }
    }
}

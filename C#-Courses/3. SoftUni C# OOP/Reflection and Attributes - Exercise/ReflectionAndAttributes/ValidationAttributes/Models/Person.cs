﻿using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Utilities.Attributes;

namespace ValidationAttributes.Models
{
    class Person
    {
        private const int MinAge = 12;
        private const int MaxAge = 90;
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }
        [MyRange(MinAge, MaxAge)]
        public int Age { get; private set; }
    }
}

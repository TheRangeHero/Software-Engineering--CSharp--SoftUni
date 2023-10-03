﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericArrayCreator
{
    class ArrayCreator
    {
       

    
        public static T[] Create<T>(int length, T item)
        {
            T[] array = new T[length];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = item;
            }

            return array;
        }

    }
}

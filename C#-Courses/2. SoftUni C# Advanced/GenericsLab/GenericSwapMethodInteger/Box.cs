using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSwapMethodInteger
{
    public class Box<T>
    {
        public List<T> ListOfInt { get; set; }



        public Box()
        {
            ListOfInt = new List<T>();
        }

        public void SwapIntMethod(int firstIndex, int secondIndex)
        {
            T placeHolder = ListOfInt[firstIndex];
            ListOfInt[firstIndex] = ListOfInt[secondIndex];
            ListOfInt[secondIndex] = placeHolder;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in ListOfInt)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().Trim();
        }
    }    
}

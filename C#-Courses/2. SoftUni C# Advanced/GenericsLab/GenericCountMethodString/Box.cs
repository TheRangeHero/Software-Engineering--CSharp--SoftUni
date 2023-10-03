using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethodString
{
   public class Box<T> where T:IComparable
    {
        public List<T> ListToCompare { get; set; }


        public Box()
        {
            ListToCompare = new List<T>();
        }

        public int Count(T itemToCompare)
        {
            int count = 0;

            foreach (var item in ListToCompare)
            {
                if (item.CompareTo(itemToCompare)>0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}

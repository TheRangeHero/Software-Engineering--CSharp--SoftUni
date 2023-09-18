using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCountMethodDouble
{
    public class Box<T> where T : IComparable
    {
        public List<T> box { get; set; }

        public Box()
        {
            box = new List<T>();
        }

        public int Count(T itemToCompare)
        {
            int count = 0;

            foreach (var item in box)
            {
                if (item.CompareTo(itemToCompare) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}

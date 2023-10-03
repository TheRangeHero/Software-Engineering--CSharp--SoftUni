using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSwapMethodString
{
    public class Box<T>
    {
        public List<T> StringList { get; set; }

        public Box()
        {
            StringList = new List<T>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in StringList)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().Trim();
        }

        public void SwapMethod(int firstIndex, int secondIndex)
        {
            T temp = StringList[firstIndex];
            StringList[firstIndex] = StringList[secondIndex];
            StringList[secondIndex]=temp;
        }
    }
}

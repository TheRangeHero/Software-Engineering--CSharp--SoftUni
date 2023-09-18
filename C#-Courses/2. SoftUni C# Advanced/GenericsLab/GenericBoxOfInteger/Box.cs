using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBoxOfInteger
{
    class Box<T>
    {
        public List<T> IntCollection { get; set; }

        public Box()
        {
            IntCollection = new List<T>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in IntCollection)
            {
                sb.AppendLine($"{typeof(T)}: {item}");

            }

            return sb.ToString().Trim(); ;
        }
    }
}

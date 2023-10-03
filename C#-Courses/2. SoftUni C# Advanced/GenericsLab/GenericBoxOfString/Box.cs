using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericBoxOfString
{
    public class Box<T>
    {

        //public T input { get; set; }

        //public Box(T input)
        //{
        //    this.input = input;
        //}


        //public override string ToString()
        //{
        //    string output = $"{typeof(T)}: {input}";
        //    return output;
        //}

        public Box()
        {
            Items = new List<T>();
        }
        public List<T> Items { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in Items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().Trim();
        }
    }
}

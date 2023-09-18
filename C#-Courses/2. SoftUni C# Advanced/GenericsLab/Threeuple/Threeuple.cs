using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threeuple
{
    class Threeuple<T1,T2,T3>
    {
        public T1 Item1 { get; set; }
        public T2 Item2{ get; set; }
        public T3 Item3 { get; set; }


        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }

    
}

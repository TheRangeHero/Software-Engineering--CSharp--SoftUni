using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericScale
{
    class EqualityScale<T>
    {
        private T right;
        private T left;
        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            bool result = this.left.Equals(right);
            return result;
        }
    }
}

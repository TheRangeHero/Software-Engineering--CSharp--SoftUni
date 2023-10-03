using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    class Snake : Reptile
    {
        public Snake(string name) : base(name)
        {
            Name = name;
        }

        public override string Name { get => base.Name; set => base.Name = value; }

    }
}

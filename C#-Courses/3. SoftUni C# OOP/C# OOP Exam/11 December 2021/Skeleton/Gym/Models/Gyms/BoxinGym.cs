using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Gyms
{
    class BoxingGym : Gym
    {
        private const int BPXING_GYM_CAPACITY = 15;

        public BoxingGym(string name) 
            : base(name, BPXING_GYM_CAPACITY)
        { }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Gyms
{
    class WeightliftingGym : Gym
    {
        private const int WEIGHTLIFTING_GYM_CAPACITY = 20;
        public WeightliftingGym(string name) 
            : base(name, WEIGHTLIFTING_GYM_CAPACITY)
        { }
    }
}

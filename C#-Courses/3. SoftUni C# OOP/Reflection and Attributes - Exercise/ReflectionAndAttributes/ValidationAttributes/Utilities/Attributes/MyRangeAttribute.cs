using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Utilities.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object value) => (int)value >= this.minValue && (int)value <= this.maxValue;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.CustomAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;

        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (!(obj is int))
            {
                throw new ArgumentException("Invalid data type");
            }

            int valueAsInt = (int)obj;
            bool isInRange = valueAsInt >= minValue && valueAsInt <= maxValue;
            if (!isInRange)
            {
                return false;
            }

            return true;
        }
    }
}

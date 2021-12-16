using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.CustomAttributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            return obj != null;
        }
    }
}

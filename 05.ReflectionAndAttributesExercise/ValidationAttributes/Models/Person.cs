using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.CustomAttributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequiredAttribute]
        public string FullName { get; set; }

        [MyRangeAttribute(12, 90)]
        public int Age { get; set; }
    }
}

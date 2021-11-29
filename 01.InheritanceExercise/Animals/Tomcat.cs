﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string DefaultGender = "male";
        public Tomcat(string name, int age) : base(name, age, DefaultGender)
        {
            Sound = "MEOW";
        }
    }
}

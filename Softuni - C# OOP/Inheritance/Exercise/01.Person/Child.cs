using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        private string name;
        private int age;
        
        public Child(string name,int age)
            :base(name,age)
        {

        }
        public new string Name { get; set; }
        public new int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value <= 15)
                {
                    age = value;
                }
            }
        }
    }
}

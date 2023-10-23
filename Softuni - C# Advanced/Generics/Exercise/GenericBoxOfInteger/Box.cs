using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxOfString
{
    public class Box<T>
    {
        private T box;
        public Box(T value)
        {
            this.box = value;
        }
        public override string ToString()
        {
            return $"{box.GetType().FullName}: {box}".ToString();
        }
    }
}

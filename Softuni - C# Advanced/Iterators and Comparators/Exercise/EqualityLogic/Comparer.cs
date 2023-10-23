using System;
using System.Collections.Generic;
using System.Text;

namespace EqualityLogic
{
    public class Comparer : IEqualityComparer<Person>
    {
            public bool Equals(Person x,Person y)
            {
                return x.CompareTo(y) == 0;
            }

            public int GetHashCode(Person obj)
            {
                return $"{obj.Name} {obj.Age}".GetHashCode();
            }
        
    }
}

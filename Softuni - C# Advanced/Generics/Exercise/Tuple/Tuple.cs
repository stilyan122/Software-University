using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T,V>
    {
        private T item1;
        private V item2;
        public Tuple(T item1,V item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }
        public T Item1 { get; set; }
        public V Item2 { get; set; }
        public override string ToString()
        {
            return $"{Item1} -> {Item2}".ToString();
        }
    }
}

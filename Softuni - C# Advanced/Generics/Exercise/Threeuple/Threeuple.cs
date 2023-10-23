using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<T,V,I>
    {
        private T item1;
        private V item2;
        private I item3;
        public Threeuple(T item1, V item2, I item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }
        public T Item1 { get; set; }
        public V Item2 { get; set; }
        public I Item3 { get; set; }
        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}".ToString();
        }
    }
}

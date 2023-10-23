using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> list;
        private readonly int count;
        public List<T> List { get {
                return this.list;
            }
            set {
                this.list = value;
            } }
        public int Count { get { return list.Count; } }

        public Box()
        {
            this.List = new List<T>();
        }
        public void Add(T element)
        {
              List.Add(element);
        }
        public T Remove()
        {
            T element = List.Last();
            List.Remove(element);
            return element;
        }
    }
}

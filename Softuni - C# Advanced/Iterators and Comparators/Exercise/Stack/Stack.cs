using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> collection;
        public Stack()
        {
            this.collection = new List<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in collection)
            {
                yield return item;
            }
        }

        public void Push(params T[] array)
        { 
            foreach (var item in array)
            {
                this.collection.Insert(0, item);
            }
        }
        public void Pop()
        {
            if (this.collection.Count==0)
            {
                Console.WriteLine("No elements");
            }
            else
            {
                this.collection.RemoveAt(0);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;
        private int index;
        public ListyIterator(List<T> collection)
        {
            this.collection = collection;
            this.index = 0;
        }
        public bool Move()
        {
            if (index+1<collection.Count)
            {
                index++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool HasNext()
        {
            if (index < collection.Count-1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.collection[index]);
            }
        }
        public void PrintAll()
        {
            foreach (var item in collection)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.collection)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
